using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public Order Order { get; set; } 

    }
}
