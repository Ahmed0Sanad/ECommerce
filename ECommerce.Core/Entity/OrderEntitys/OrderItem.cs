using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerce.Core.Entity.OrderEntitys
{
    public  class OrderItem : BaseEntity
    {
        public OrderItem()
        {
            
        }

        public OrderItem(OrderProduct product, decimal price, int quantity)
        {
            Product = product;
            Price = price;
            Quantity = quantity;
            
        }

        public OrderProduct Product { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
        [JsonIgnore] 
        public Order Order { get; set; } 

    }
}
