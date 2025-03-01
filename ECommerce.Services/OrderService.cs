using ECommerce.Core;
using ECommerce.Core.Entity;
using ECommerce.Core.Entity.OrderEntitys;
using ECommerce.Core.Entity.rides;
using ECommerce.Core.Repository.Contract;
using ECommerce.Core.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBasketRepository _basketRepository;

        public OrderService(
            IUnitOfWork unitOfWork,
            IBasketRepository basketRepository
            )
        {
            _unitOfWork = unitOfWork;
            _basketRepository = basketRepository;
        }
        public async Task<Order?> CreateOrderAsync(string BuyerEmail, int DeliveryMethodId, string BasketId, Address address)
        {
            //get basket
            CustomerBasket? basket = await _basketRepository.GetCustomerBasket(BasketId);
            var OrderItems = new List<OrderItem>();
            if (basket != null)
            {
                //get items from basket
                var items = basket.Products;
                //set all items in orderitem
                var productRepo = _unitOfWork.GetRepository<Product>();
                foreach (var item in items)
                {
                    var DbProduct = await productRepo.GetAsync(item.Id);
                    var product = new OrderProduct(item.Id, item.Name, item.PictureUrl);
                    var orderItem = new OrderItem(product, DbProduct.Price, item.Quantity);
                    OrderItems.Add(orderItem);
                }
            }
            //calc subTotal
            var subtotal = OrderItems.Sum(item => item.Price);
            // get delivery method
            
            var delivery = await _unitOfWork.GetRepository<DeliveryMethod>().GetAsync(DeliveryMethodId);
            if (delivery is null) { return null; }
            //add order
            var order = new Order(BuyerEmail, OrderItems, delivery, subtotal, address);
            await _unitOfWork.GetRepository<Order>().AddAsync(order);
            //save db
            var result = await _unitOfWork.CompleteAsync();
            if (result > 0)
            {
                return order;
            }
            return null;
        }
    }
}
