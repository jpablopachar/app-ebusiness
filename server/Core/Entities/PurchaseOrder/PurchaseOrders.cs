namespace Core.Entities.PurchaseOrder
{
    public class PurchaseOrders : Base
    {
        public string? BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public Address ShipToAddress { get; set; }
        public ShippingType ShippingType { get; set; }
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public decimal Subtotal { get; set; }
        public OrderStatus Status { get; set; }
        public string? PaymentAttempt { get; set; }

        public PurchaseOrders() { }

        public PurchaseOrders(string? buyerEmail, Address shipToAddress, ShippingType shippingType, IReadOnlyList<OrderItem> orderItems, decimal subtotal)
        {
            BuyerEmail = buyerEmail;
            ShipToAddress = shipToAddress;
            ShippingType = shippingType;
            OrderItems = orderItems;
            Subtotal = subtotal;
        }

        public decimal GetTotal()
        {
            return Subtotal + ShippingType.Price;
        }
    }
}