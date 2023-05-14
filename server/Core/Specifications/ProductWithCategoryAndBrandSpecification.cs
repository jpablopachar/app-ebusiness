using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithCategoryAndBrandSpecification : Specification<Product>
    {
        public ProductWithCategoryAndBrandSpecification()
        {
            AddInclude(product => product.Category);
            AddInclude(product => product.Brand);
        }

        public ProductWithCategoryAndBrandSpecification(int id) : base(product => product.Id == id)
        {
            AddInclude(product => product.Category);
            AddInclude(product => product.Brand);
        }
    }
}