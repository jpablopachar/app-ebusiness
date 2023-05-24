using Core.Entities;
using Core.Entities.PurchaseOrder;
using Core.Interfaces;
using Core.Specifications;

namespace BusinessLogic.Logic
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseOrderService(IShoppingCartRepository shoppingCartRepository, IUnitOfWork unitOfWork)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PurchaseOrders?> AddShippingOrderAsync(string buyerEmail, int shippingType, string shoppingCartId, Core.Entities.PurchaseOrder.Address address)
        {
            var shoppingCart = await _shoppingCartRepository.GetShoppingCartAsync(shoppingCartId);

            var items = new List<OrderItem>();

            foreach (var item in shoppingCart.Items)
            {
                var productItem = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);

                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.Image);

                var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Amount);

                items.Add(orderItem);
            }

            var shippingTypeEntity = await _unitOfWork.Repository<ShippingType>().GetByIdAsync(shippingType);

            var subtotal = items.Sum(item => item.Price * item.Quantity);

            var purchaseOrder = new PurchaseOrders(buyerEmail, address, shippingTypeEntity, items, subtotal);

            _unitOfWork.Repository<PurchaseOrders>().AddEntity(purchaseOrder);

            var result = await _unitOfWork.Complete();

            if (result <= 0) return null;

            await _shoppingCartRepository.DeleteShoppingCartAsync(shoppingCartId);

            return purchaseOrder;
        }

        public async Task<PurchaseOrders> GetPurchaseOrderByIdAsync(int id, string email)
        {
            var spec = new PurchaseOrderWithItemsSpecification(id, email);

            return await _unitOfWork.Repository<PurchaseOrders>().GetByIdWithSpec(spec);
        }

        public async Task<IReadOnlyList<PurchaseOrders>> GetPurchaseOrdersByUserEmailAsync(string buyerEmail)
        {
            var spec = new PurchaseOrderWithItemsSpecification(buyerEmail);

            return await _unitOfWork.Repository<PurchaseOrders>().GetAllWithSpec(spec);
        }

        public async Task<IReadOnlyList<ShippingType>> GetShippingTypesAsync()
        {
            return await _unitOfWork.Repository<ShippingType>().GetAllAsync();
        }
    }
}