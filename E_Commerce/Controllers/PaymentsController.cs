using E_Commerce.Errors;
using ECommerce.Core;
using ECommerce.Core.Entity.OrderEntitys;
using ECommerce.Core.Helper;
using ECommerce.Core.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
       
        private readonly IStripeService _stripeService;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentsController(IStripeService stripeService, IUnitOfWork unitOfWork)
        {
            this._stripeService = stripeService;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Creates a PaymentIntent and returns the Client Secret.
        /// </summary>
        [HttpPost("create-payment-intent")]
        public async Task<ActionResult<string>> CreatePaymentIntent(int orderId)
        {
            var order = await _unitOfWork.GetRepository<Order>().GetByIdAsync(orderId);
            StripeResponseServ stripeResponse = await _stripeService.CreateCheckoutSession(order);
            switch (stripeResponse.statusCode)
            {
                case HttpStatusCode.OK:
                    return Ok(stripeResponse.Url);
                case HttpStatusCode.NotFound:
                    return NotFound(stripeResponse.ErrorMassage);
                default:
                    return BadRequest( new ApiResponse(500));
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
            var stripeRsponse= _stripeService.HandleStripeWebhookAsync(json);

            return Ok(stripeRsponse);
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
