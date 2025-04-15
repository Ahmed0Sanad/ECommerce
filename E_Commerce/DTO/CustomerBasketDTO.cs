

namespace E_Commerce.DTO
{
    public class CustomerBasketDTO
    {
        public string Id { get; set; }
        public List<BasketProductDTO> Products { get; set; }
        public int DeliveryMethodId { get; set; }
        public string? ClientSecret  { get; set; }
        public string? PaymentIntentId { get; set; }
        public decimal ShippingCost { get; set; }
    }
}
