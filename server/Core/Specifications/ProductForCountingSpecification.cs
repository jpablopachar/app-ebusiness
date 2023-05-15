using Core.Entities;

namespace Core.Specifications
{
    public class ProductForCountingSpecification : Specification<Product>
    {
        public ProductForCountingSpecification(ProductSpecificationParams productParams) : base(product => (string.IsNullOrEmpty(productParams.Search) || product.Name.Contains(productParams.Search)) && (!productParams.Brand.HasValue || product.BrandId == productParams.Brand) && (!productParams.Category.HasValue || product.CategoryId == productParams.Category))
        { }
    }
}