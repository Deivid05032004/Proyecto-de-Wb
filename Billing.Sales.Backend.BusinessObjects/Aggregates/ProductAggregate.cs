

using System.Security.Cryptography;

namespace Billing.Sales.Backend.BusinessObjects.Aggregates;

public class ProductAggregate : Product
{
    public static ProductAggregate CresteProductFrom(CreateProductDto product)
    {
        ProductAggregate productAggregate = new()
        {
            Name = product.Name,
            Brand = product.Brand,
            Presentation = product.Presentation,
            Stock = product.Stock,
            Price = product.Price,
        };
        return productAggregate;

    }
    public void UpdateProductFrom(CreateProductDto product) 
    {
        Name = product.Name;
        Brand = product.Brand;
        Presentation = product.Presentation;
        Stock = product.Stock;
        Price = product.Price;

    }
    public static ProductAggregate FromEntity(Product product)
    {
        return new ProductAggregate
        {
            Id = product.Id,
            Name = product.Name,
            Brand = product.Brand,
            Presentation = product.Presentation,
            Stock = product.Stock,
            Price = product.Price
        };
    }

}
