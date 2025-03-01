using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entity.OrderEntitys
{
    public class Order : BaseEntity
    {
        public Order()
        {
            
        }

        public Order(string buyerEmail, ICollection<OrderItem> orderItems, DeliveryMethod? deliveryMethod, decimal subtotal,Address address)
        {
            BuyerEmail = buyerEmail;
            ShippingAddress = address;
            DeliveryMethod = deliveryMethod;
            Subtotal = subtotal;
        }

        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.UtcNow;
        public OrderStatus Status { get; set; }
        public Address ShippingAddress { get; set; }

        public DeliveryMethod? DeliveryMethod { get; set; }
        public ICollection<OrderItem> Items { get; set; }   = new HashSet<OrderItem>();
        public decimal Subtotal { get; set; }
        public int? PaymentIntentId { get; set; }
        public decimal Total => Subtotal + DeliveryMethod.Cost;


    }
}
