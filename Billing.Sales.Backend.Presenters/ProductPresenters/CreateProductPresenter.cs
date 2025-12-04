

using Billing.Sales.Backend.BusinessObjects.Aggregates;
using Billing.Sales.Backend.BusinessObjects.Interfaces.Products;
using Billing.Sales.Backend.BusinessObjects.POCOEntities;

namespace Billing.Sales.Backend.Presenters.ProductPresenters
{
    public class CreateProductPresenter : IProductOuputPort
    {
        public IEnumerable<ProductAggregate>? Products { get; private set; }
        public ProductAggregate? Product { get; private set; }
        public IEnumerable<ProductAggregate> productsList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ProductAggregate? ProductById { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task PresentAllProducts(IEnumerable<ProductAggregate> products)
        {
            Products = products;
            return Task.CompletedTask;
        }

        public Task PresentProduct(ProductAggregate? product)
        {
            Product = product;
            return Task.CompletedTask;
        }

        public Task PresentProductCreated(ProductAggregate product)
        {
            Product = product;
            return Task.CompletedTask;
        }

        public Task PresentProductDeleted(int productId)
        {
            // Puedes guardar el ID si lo necesitas
            return Task.CompletedTask;
        }

        public Task PresentProductUpdated(int productId, ProductAggregate? product)
        {
            Product = product;
            return Task.CompletedTask;
        }
    }
}
