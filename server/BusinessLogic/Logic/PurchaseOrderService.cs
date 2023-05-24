using Core.Entities;
using Core.Entities.PurchaseOrder;
using Core.Interfaces;

namespace BusinessLogic.Logic
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IGenericRepository<PurchaseOrders> _purchaseOrderRepository;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IGenericRepository<ShippingType> _shippingTypeRepository;

        public PurchaseOrderService(IGenericRepository<PurchaseOrders> purchaseOrderRepository, IGenericRepository<Product> productRepository, IShoppingCartRepository shoppingCartRepository, IGenericRepository<ShippingType> shippingTypeRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
            _productRepository = productRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _shippingTypeRepository = shippingTypeRepository;
        }

        public async Task<PurchaseOrders> AddShippingOrderAsync(string buyerEmail, int shippingType, string shoppingCartId, Core.Entities.PurchaseOrder.Address address)
        {
            var shoppingCart = await _shoppingCartRepository.GetShoppingCartAsync(shoppingCartId);

            var items = new List<OrderItem>();

            foreach (var item in shoppingCart.Items) {
                var productItem = await _productRepository.GetByIdAsync(item.Id);

                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.Image);

                var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Amount);

                items.Add(orderItem);
            }

            var shippingTypeEntity = await _shippingTypeRepository.GetByIdAsync(shippingType);

            var subtotal = items.Sum(item => item.Price * item.Quantity);

            var purchaseOrder = new PurchaseOrders(buyerEmail, address, shippingTypeEntity, items, subtotal);

            return purchaseOrder;
        }

        public Task<PurchaseOrders> GetPurchaseOrderByIdAsync(int id, string email)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<PurchaseOrders>> GetPurchaseOrdersByUserEmailAsync(string buyerEmail)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<ShippingType>> GetShippingTypesAsync()
        {
            throw new NotImplementedException();
        }
    }
}