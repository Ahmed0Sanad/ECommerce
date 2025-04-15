using E_Commerce.Errors;
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

        public PaymentsController(IStripeService stripeService)
        {
            this._stripeService = stripeService;
        }

        /// <summary>
        /// Creates a PaymentIntent and returns the Client Secret.
        /// </summary>
        [HttpPost("create-payment-intent")]
        public async Task<ActionResult<string>> CreatePaymentIntent(string basketId)
        {
            StripeResponseServ stripeResponse = await _stripeService.CreateCheckoutSession(basketId);
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
            Console.WriteLine("haaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaay");

           
            return Ok();
        }
    }
}
