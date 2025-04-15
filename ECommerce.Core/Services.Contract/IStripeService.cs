using ECommerce.Core.Entity.rides;
using ECommerce.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Services.Contract
{
    public interface IStripeService
    {
        public  Task<StripeResponseServ> CreateCheckoutSession(string basketId);
    }
}
