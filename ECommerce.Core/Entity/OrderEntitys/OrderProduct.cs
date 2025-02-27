using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entity.OrderEntitys
{
    public class OrderProduct
    {
        public OrderProduct()
        {
            
        }

        public OrderProduct(int id, string productName, string pictureUrl)
        {
            Id = id;
            ProductName = productName;
            PictureUrl = pictureUrl;
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public  string PictureUrl   { get; set; }

    }
}
