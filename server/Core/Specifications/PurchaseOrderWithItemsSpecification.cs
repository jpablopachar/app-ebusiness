using Core.Entities.PurchaseOrder;

namespace Core.Specifications
{
    public class PurchaseOrderWithItemsSpecification : Specification<PurchaseOrders>
    {
        public PurchaseOrderWithItemsSpecification(string email) : base(o => o.BuyerEmail == email)
        {
            AddInclude(o => o.OrderItems);
            AddInclude(o => o.ShippingType);
            AddOrderByDescending(o => o.OrderDate);
        }

        public PurchaseOrderWithItemsSpecification(int id, string email) : base(o => o.BuyerEmail == email && o.Id == id)
        {
            AddInclude(o => o.OrderItems);
            AddInclude(o => o.ShippingType);
            AddOrderByDescending(o => o.OrderDate);
        }
    }
}