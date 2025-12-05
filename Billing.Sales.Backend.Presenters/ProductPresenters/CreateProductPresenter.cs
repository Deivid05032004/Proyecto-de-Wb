using Billing.Sales.Backend.BusinessObjects.Aggregates;
using Billing.Sales.Backend.BusinessObjects.Interfaces.Products;
using Billing.Sales.Backend.BusinessObjects.POCOEntities;

namespace Billing.Sales.Backend.Presenters.ProductPresenters
{
    public class CreateProductPresenter : IProductOuputPort
    {
        public IEnumerable<ProductAggregate>? Products { get; private set; }
        public ProductAggregate? Product { get; private set; }

        // ← estas son las propiedades que antes lanzaban NotImplementedException
        public IEnumerable<ProductAggregate> productsList { get; set; }
        public ProductAggregate? ProductById { get; set; }

        public Task PresentAllProducts(IEnumerable<ProductAggregate> products)
        {
            Products = products;
            productsList = products;
            return Task.CompletedTask;
        }

        public Task PresentProduct(ProductAggregate? product)
        {
            Product = product;
            ProductById = product;
            return Task.CompletedTask;
        }

        public Task PresentProductCreated(ProductAggregate product)
        {
            Product = product;
            ProductById = product;
            return Task.CompletedTask;
        }

        public Task PresentProductDeleted(int productId)
        {
            return Task.CompletedTask;
        }

        public Task PresentProductUpdated(int productId, ProductAggregate? product)
        {
            Product = product;
            ProductById = product;
            return Task.CompletedTask;
        }
    }
}
