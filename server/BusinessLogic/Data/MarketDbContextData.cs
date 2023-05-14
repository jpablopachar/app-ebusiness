using System.Text.Json;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace BusinessLogic.Data
{
    public class MarketDbContextData
    {
        public static async Task LoadDataAsync(MarketDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Brand.Any())
                {
                    var brandData = File.ReadAllText("../BusinessLogic/InitialData/brand.json");
                    var brands = JsonSerializer.Deserialize<List<Brand>>(brandData);

                    foreach (var brand in brands)
                    {
                        context.Brand.Add(brand);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Category.Any())
                {
                    var categoryData = File.ReadAllText("../BusinessLogic/InitialData/category.json");
                    var categories = JsonSerializer.Deserialize<List<Category>>(categoryData);

                    foreach (var category in categories)
                    {
                        context.Category.Add(category);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Product.Any())
                {
                    var productData = File.ReadAllText("../BusinessLogic/InitialData/product.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productData);

                    foreach (var product in products)
                    {
                        context.Product.Add(product);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                var logger = loggerFactory.CreateLogger<MarketDbContextData>();

                logger.LogError(exception.Message);
            }
        }
    }
}