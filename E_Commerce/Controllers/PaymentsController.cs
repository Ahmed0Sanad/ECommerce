using E_Commerce.Errors;
using ECommerce.Core;
using ECommerce.Core.Entity.OrderEntitys;
using ECommerce.Core.Helper;
using ECommerce.Core.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using System.Net;
namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {

        private readonly IStripeService _stripeService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public PaymentsController(IStripeService stripeService, IUnitOfWork unitOfWork , ILogger<PaymentsController> logger)
        {
            this._stripeService = stripeService;
            this._unitOfWork = unitOfWork;
            this._logger = logger;
        }

        /// <summary>
        /// Creates a PaymentIntent and returns the Client Secret.
        /// </summary>

        [HttpPost("create-payment-intent")]

        public async Task<ActionResult<string>> CreatePaymentIntent(int orderId)
        {

            var order = await _unitOfWork.GetRepository<Order>().GetByIdAsync(orderId);
            if (order == null)
            {
                return NotFound(new ApiResponse(404,"No Order Exist With This ID"));
            }
            else if (order.Status == OrderStatus.PaymentSuccess)
            {
                return BadRequest(new ApiResponse(400, "THis Order Is Paid"));
            }
  
                StripeResponseServ stripeResponse = await _stripeService.CreateCheckoutSession(order);

            switch (stripeResponse.statusCode)
            {

                case HttpStatusCode.OK:

                    return Ok(stripeResponse.Url);

                case HttpStatusCode.NotFound:

                    return NotFound(stripeResponse.ErrorMassage);

                default:

                    return BadRequest(new ApiResponse(500));

            }


        }

        /// <summary>
        /// Confirms a PaymentIntent with a PaymentMethod.
        /// </summary>
        /// 
        [AllowAnonymous]
        [HttpPost("/webhook")]
        //[ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> HandleStripeWebhook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            // Validate webhook signature
            var stripeEvent = EventUtility.ParseEvent(json);

            var session = stripeEvent.Data.Object as Session;

            var clientReferenceId = session.ClientReferenceId;
            var orderId = int.Parse(clientReferenceId);
            var order = await _unitOfWork.GetRepository<Order>().GetByIdAsync(orderId);


            order.PaymentIntentId = session.PaymentIntentId;
            // Handle the event based on its type
            switch (stripeEvent.Type)
            {
                case EventTypes.CheckoutSessionCompleted:

                    order.Status = OrderStatus.PaymentSuccess;
                    _logger.LogInformation($"{stripeEvent.Type}");


                    break;
                case EventTypes.CheckoutSessionExpired:
                    order.Status = OrderStatus.PaymentFailure;
                    _logger.LogInformation($"{stripeEvent.Type}");
                    break;

                default:
                    _logger.LogInformation("Unhandled event type: {EventType}", stripeEvent.Type);
                    break;
            }
            var reselt = _unitOfWork.CompleteAsync();
            if (reselt.Result == 0)
            {
                // _logger.LogError("Failed to update order status in database");
                return BadRequest();
            }
            

            return Ok();
        }
        [HttpGet("success")]
        public async Task<string> SuccessPage()
        {
            return ("Order Payment Successed");
        }
        [HttpGet("faild")]

        public async Task<string> Faildpage()
        {
            return ("Order Payment Faild");
        }
    }
}
