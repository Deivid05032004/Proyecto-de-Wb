

namespace Billing.Sales.Backend.Repositories.Interfaces.ProductCommand
{
    public interface IProductBillingSalesCommandDataContext
    {
        // ============================
        // PRODUCTS
        // ============================
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(Product product);

        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task SavesChangesAsync();

    }
}
