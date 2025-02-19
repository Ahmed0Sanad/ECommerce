using ECommerce.Core.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.DTO
{
    public class ProductDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
       
        public int CategoryId { get; set; }
        public string Category { get; set; }
      
        public int BrandId { get; set; }
        public string Brand { get; set; }
    }
}
