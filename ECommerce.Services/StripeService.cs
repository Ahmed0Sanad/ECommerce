using ECommerce.Core;
using ECommerce.Core.Entity;
using ECommerce.Core.Entity.OrderEntitys;
using ECommerce.Core.Entity.rides;
using ECommerce.Core.Repository.Contract;
using ECommerce.Core.Services.Contract;
using ECommerce.Core.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Product = ECommerce.Core.Entity.Product;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using ECommerce.Core.Entity.Identity;

namespace ECommerce.Services
{
    public class StripeService : IStripeService
    {
        private readonly IUnitOfWork _unitOfWork;
       
        private readonly IConfiguration _configuration;
        public readonly ILogger<StripeService> _logger;
        private readonly UserManager<AppUser> _userManager;

        public StripeService(IUnitOfWork unitOfWork, IConfiguration configuration, ILogger<StripeService> logger , UserManager<AppUser> userManager)
        {
            this._unitOfWork = unitOfWork;
            this._configuration = configuration;
            _logger = logger;
            this._userManager = userManager;
        }

 

        // v 1 => need frontend to call this methods
        //service to call stripe api from step 2
        //private readonly PaymentIntentService _paymentIntentService;
        ////step 2
        //this._paymentIntentService = new PaymentIntentService();
        //public async Task<CustomerBasket?> CreateOrUpdatePayment(string basketId)
        //{
        //    //step 1
        //    StripeConfiguration.ApiKey = _configuration["stripe:SecretKey"];
        //    var basket = await _basketRepository.GetCustomerBasket(basketId);
        //    decimal totalAmount = 0m;
        //    if (basket == null) { return null; }
        //    var items = basket.Products;

        //    foreach (var item in items) 
        //    {
        //        var dbProduct= await _unitOfWork.GetRepository<Product>().GetByIdAsync(item.Id);
        //        if(dbProduct == null) { continue; }
        //        item.Price = dbProduct.Price;
        //        item.PictureUrl = dbProduct.PictureUrl;
        //        totalAmount += dbProduct.Price * item.Quantity;
        //    }
        //    if (basket.ShippingCost != 0)
        //    {
        //        if(basket.DeliveryMethodId  != 0)
        //        {
        //            var delId = basket.DeliveryMethodId; 
        //            var deliveryMethod = await _unitOfWork.GetRepository<DeliveryMethod>().GetByIdAsync(delId??0);
        //            basket.ShippingCost = deliveryMethod.Cost;
        //            totalAmount += basket.ShippingCost;
        //        }

        //    }

        //    //--------
        //    //payment send to stripeService
        //    //not nessary but i use it to catch the paymentInten info and save it in the basket
        //    PaymentIntent intent;
        //    //-------------
        //    // step 3
        //    var options = new PaymentIntentCreateOptions
        //    {
        //        Amount = (long)(totalAmount * 100), // Convert to cents
        //        Currency = "usd", // Change to your preferred currency
        //        PaymentMethodTypes = new List<string> { "card" },

        //    };

        //    if (string.IsNullOrEmpty(basket.PaymentIntentId))
        //    {
        //        //step 4
        //        intent = await _paymentIntentService.CreateAsync(options);
        //        basket.PaymentIntentId = intent.Id;
        //        basket.ClientSecret = intent.ClientSecret;
        //    }
        //    else
        //    {
        //        var updateOptions = new PaymentIntentUpdateOptions { Amount = (long)(totalAmount * 100) };
        //        // not nessary but we use it to update paymentIntent
        //        await _paymentIntentService.UpdateAsync(basket.PaymentIntentId, updateOptions);
        //    }

        //    await _basketRepository.SetCustomerBasket(basket);

        //    return basket;
        //    //-------



        //}
        //public async Task<PaymentIntent> ConfirmPaymentIntent(string paymentIntentId, string paymentMethodId)
        //{
        //    var service = new PaymentIntentService();
        //    var options = new PaymentIntentConfirmOptions
        //    {
        //        PaymentMethod = paymentMethodId
        //    };

        //    return await service.ConfirmAsync(paymentIntentId, options);
        //}


        public async Task<StripeResponseServ> CreateCheckoutSession(Order order)
        {
            StripeConfiguration.ApiKey = _configuration["stripe:SecretKey"];


            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                      {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "usd",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name =  $"Order {order.Id}"
                            },
                            UnitAmount = (long) order.Total*100     // $50.00,

                        },
                        Quantity = 1,
                 }
                },
                Mode = "payment",
                

                SuccessUrl = $"{_configuration["ApiSecureUrl"]}/api/Payments/success",
                CancelUrl = $"{_configuration["ApiSecureUrl"]}/api/Payments/faild",
                PaymentIntentData = new SessionPaymentIntentDataOptions { CaptureMethod = "automatic" },
                ClientReferenceId = $"{order.Id}"
            };

            var service = new SessionService();
            var session = await service.CreateAsync(options);
            
            return new StripeResponseServ() { statusCode=HttpStatusCode.OK,Url=session.Url};
        }
      

    }
}
