
namespace Billing.Sales.Fronend.Business.Objects.Interfaces
{
    public interface IProductGateway
    {
        Task<int> CreateProductAsync(CreateProductDto productDto);
        Task UpdateProductAsync(int idProduct, CreateProductDto productDto);
        Task<IEnumerable<CreateProductDto>> GetAllProductsAsyncs();
        Task<CreateProductDto> GetProductById(int id);
        Task DeleteProductAsync(int id);
    }
}
