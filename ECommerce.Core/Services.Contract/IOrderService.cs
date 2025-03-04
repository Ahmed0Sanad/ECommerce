using ECommerce.Core.Entity.OrderEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Services.Contract
{
    public interface IOrderService
    {
        public Task<Order?> CreateOrderAsync(string BuyerEmail, int DeliveryMethodId, string BasketId, Address address);
        public  Task<IEnumerable<Order?>> GetOrdersAsync(string BuyerEmail);
        public  Task<Order?> GetOrderByIdAsync(int OrderId, string buyerEmail);
    }
}
