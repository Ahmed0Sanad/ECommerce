using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTO
{
    public class BasketProductDTO
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [Range(1, double.MaxValue)]
        public decimal Price { get; set; }
        [MaxLength(100)]

        public string PictureUrl { get; set; }
        [MaxLength(100)]

        public string Category { get; set; }
        [MaxLength(100)]

        public string Brand { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
