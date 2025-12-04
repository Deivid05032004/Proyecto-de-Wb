
namespace Billing.Sales.Backend.BusinessObjects.Interfaces.Repositories
{
    public interface ICommandsProductRepository : IUnitOfWork
    {
        Task CreateProduct(ProductAggregate product);
        Task UpdateProduct(ProductAggregate product);
        Task<IEnumerable<ProductAggregate>> GetAllProducts();
        Task DeleteProduct(ProductAggregate product);
        Task<ProductAggregate> GetProductById(int id);
    }
}
