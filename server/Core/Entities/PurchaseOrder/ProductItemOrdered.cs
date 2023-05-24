namespace Core.Entities.PurchaseOrder
{
    public class ProductItemOrdered
    {
        public int ProductItemId { get; set; }
        public string? ProductName { get; set; }
        public string? ImageUrl { get; set; }

        public ProductItemOrdered() { }

        public ProductItemOrdered(int productItemId, string? productName, string? imageUrl)
        {
            ProductItemId = productItemId;
            ProductName = productName;
            ImageUrl = imageUrl;
        }
    }
}