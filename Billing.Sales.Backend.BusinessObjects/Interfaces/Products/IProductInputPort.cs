

namespace Billing.Sales.Backend.BusinessObjects.Interfaces.Products;

public interface IProductInputPort
{
    Task HandleCreateProduct(CreateProductDto product);
    Task HandleGetAllProducts();
    Task HandleUpdateProduct(int productId, CreateProductDto product);
    Task HandleDeleteProduct(int productId);
    Task HandleGetProductById(int productId);

}
