using Core.Entities.PurchaseOrder;

namespace WebApi.Dtos
{
    public class PurchaseOrderResponseDto
    {
        public int Id { get; set; }
        public string? BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public Address? ShipToAddress { get; set; }
        public string? ShippingType { get; set; }
        public decimal ShippingTypePrice { get; set; }
        public IReadOnlyList<OrderItem>? OrderItems { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public OrderStatus Status { get; set; }
    }
}