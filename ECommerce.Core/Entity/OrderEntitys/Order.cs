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

        public Order(string buyerEmail, DateTimeOffset orderDate, OrderStatus status, DeliveryMethod? deliveryMethod, decimal subtotal)
        {
            BuyerEmail = buyerEmail;
            OrderDate = orderDate;
            Status = status;
            DeliveryMethod = deliveryMethod;
            Subtotal = subtotal;
        }

        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.UtcNow;
        public OrderStatus Status { get; set; }
        public Address ShippingAddress { get; set; }

        public DeliveryMethod? DeliveryMethod { get; set; }
        public decimal Subtotal { get; set; }
        public int? PaymentIntentId { get; set; }
        public decimal Total => Subtotal + DeliveryMethod.Cost;


    }
}
