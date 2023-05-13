using Core.Entities;
using Core.Interfaces;

namespace BusinessLogic.Logic
{
    public class ProductRepository : IProductRepository
    {
        public Task<Product> GetProductByIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }
    }
}