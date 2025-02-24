using ECommerce.Core.Entity.rides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Repository.Contract
{
    public interface IBasketRepository
    {
        public Task<CustomerBasket?> GetCustomerBasket(string id);
        public Task<CustomerBasket?> SetCustomerBasket( CustomerBasket cart);
        public Task DeleteCustomerBasket(string id);
    }
}
