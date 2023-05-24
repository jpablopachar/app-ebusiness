namespace Core.Entities.PurchaseOrder
{
    public class OrderItem : Base
    {
        public ProductItemOrdered? ItemOrdered { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public OrderItem() { }

        public OrderItem(ProductItemOrdered? itemOrdered, decimal price, int quantity)
        {
            ItemOrdered = itemOrdered;
            Price = price;
            Quantity = quantity;
        }
    }
}