using Core.Entities.PurchaseOrder;

namespace Core.Interfaces
{
    public interface IPurchaseOrderService
    {
        Task<PurchaseOrders> AddShippingOrderAsync(string buyerEmail, int shippingType, string shoppingCartId, Address address);

        Task<IReadOnlyList<PurchaseOrders>> GetPurchaseOrdersByUserEmailAsync(string buyerEmail);

        Task<PurchaseOrders> GetPurchaseOrderByIdAsync(int id, string email);

        Task<IReadOnlyList<ShippingType>> GetShippingTypesAsync();
    }
}