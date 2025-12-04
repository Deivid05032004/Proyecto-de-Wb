

using Billing.Sales.Backend.BusinessObjects.Interfaces.Repositories;
using Billing.Sales.Backend.Repositories.Interfaces;

namespace Billing.Sales.Backend.Repositories.Repositories
{
    public class CommandsRepository(IBillingSalesCommandDataContext context) : ICommandsProductRepository
    {
        public Task CreateProduct(ProductAggregate product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProduct(ProductAggregate product)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductAggregate>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<ProductAggregate> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(ProductAggregate product)
        {
            throw new NotImplementedException();
        }
    }
}
