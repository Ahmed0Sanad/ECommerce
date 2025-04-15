using ECommerce.Core.Entity.OrderEntitys;

namespace E_Commerce.DTO
{
    public class OrderToReturnDto
    {
        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } 
        public string Status { get; set; }
        public Address ShippingAddress { get; set; }

        public string DeliveryMethod { get; set; }
        public decimal DeliveryMethodCost { get; set; }
        public ICollection<OrderItemDto> Items { get; set; } = new HashSet<OrderItemDto>();
        public decimal Subtotal { get; set; }
        public string PaymentIntentId { get; set; }

        public decimal Total => Subtotal + (DeliveryMethodCost);

    }
}
