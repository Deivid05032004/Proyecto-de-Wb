
namespace Billing.Sales.Backend.Repositories.Repositories
{
    internal class ProductCommandsRepository(IBillingSalesCommandDataContext context) : ICommandsProductRepository
    {
        public async Task CreateProduct(ProductAggregate product)
        {
            await context.AddProductAsync(product);
        }

        public async Task DeleteProduct(ProductAggregate product)
        {
            await context.DeleteProductAsync(product);  
        }

        public async Task<IEnumerable<ProductAggregate>> GetAllProducts()
        {
            var products = await context.GetAllProductsAsync();

            return products.Select(ProductAggregate.FromEntity);
        }

        public async Task<ProductAggregate> GetProductById(int id)
        {
            var product = await context.GetProductByIdAsync(id);

            if (product is null)
                return null;

            return ProductAggregate.FromEntity(product);
        }

        public async Task SaveChanges()
        {
           await context.SaveChangesAsync();
        }

        public async Task UpdateProduct(ProductAggregate product)
        {
            await context.UpdateProductAsync(product);
        }
    }
    
}
