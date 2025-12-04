
using Billing.Sales.Backend.BusinessObjects.Aggregates;

namespace Billing.Sales.Backend.BusinessObjects.Interfaces.Products;

public interface IProductOuputPort
{
    Task PresentProductCreated(ProductAggregate product);
    Task PresentAllProducts();
    IEnumerable<ProductAggregate> productsList { get; set; }
    Task PresentProduct(ProductAggregate product);
    ProductAggregate?  ProductById { get; set; }
    Task PresentProductUpdated(int productId, ProductAggregate product);
    Task PresentProductDeleted(int productId);

}
