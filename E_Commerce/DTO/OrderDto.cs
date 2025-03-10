using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTO
{
    public class OrderDto
    {
       // string BuyerEmail, int DeliveryMethodId, string BasketId, Address address
       
        [Required]

        public int DeliveryMethodId { get; set; }
        [Required]

        public string BasketId { get; set; }
        [Required]

        public AddressDto ShippingAddress { get; set; }

    }
}