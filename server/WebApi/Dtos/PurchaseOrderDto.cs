namespace WebApi.Dtos
{
    public class PurchaseOrderDto
    {
        public string? ShoppingCartId { get; set; }
        public int ShippingType { get; set; }
        public AddressDto? ShippingAddress { get; set; }
    }
}