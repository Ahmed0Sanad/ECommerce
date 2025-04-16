using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entity.rides
{
    public class CustomerBasket
    {
        public string Id { get; set; }
        public List<BasketProduct> Products { get; set; }
        
        public decimal ShippingCost { get; set; }
       
        public int? DeliveryMethodId { get; set; }
        public string ClientSecret { get; set; }
     
        public CustomerBasket()
        {

            Products = new List<BasketProduct>();
        }
    }
}
