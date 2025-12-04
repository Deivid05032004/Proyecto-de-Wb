
using Billing.Sales.Backend.BusinessObjects.Interfaces.Products;

namespace Billing.Sales.Backend.Contollers.CreateProduct
{
    public static class ProductController
    {
        public static WebApplication UseProductsController(this WebApplication app)
        {
            app.MapPost(EndPoints.Products, CreateProduct);
            app.MapGet(EndPoints.Products, GetAllProducts);
            app.MapGet(EndPoints.Products, GetProductById);
            app.MapPut(EndPoints.Products, UpdateProduct);
            app.MapDelete(EndPoints.Products, DeleteProduct);
            return app;
        }
        private static async Task<int> CreateProduct(
            CreateProductDto dto,
            IProductInputPort inputPort,
            IProductOuputPort ouputPort) 
        {
            await inputPort.HandleCreateProduct(dto);
            return ouputPort.ProductById.Id;
        }

        private static async Task<IEnumerable<object>> GetAllProducts(
            IProductInputPort inputPort,
            IProductOuputPort ouputPort) 
        {
            await inputPort.HandleGetAllProducts();
            return ouputPort.productsList.Select(p => new
            {
                p.Id,
                p.Name,
                p.Presentation,
                p.Price,
                p.Stock
            });
        }

        private static async Task<object?> GetProductById(
            int id,
            IProductInputPort inputPort,
            IProductOuputPort ouputPort) 
        {
            await inputPort.HandleGetProductById(id);
            if (ouputPort.ProductById is null) 
            {
                return null;
            }
            return new
            {
                ouputPort.ProductById.Id,
                ouputPort.ProductById.Name,
                ouputPort.ProductById.Presentation,
                ouputPort.ProductById.Price,
                ouputPort.ProductById.Stock
            };
        }
        private static async Task<bool> UpdateProduct(
            int id,
            CreateProductDto dto,
            IProductInputPort inputPort,
            IProductOuputPort ouputPort)
        {
            await inputPort.HandleUpdateProduct(id,dto);
            return true;

        }
        private static async Task<bool> DeleteProduct(
            int id,
            IProductInputPort inputPort,
            IProductOuputPort ouputPort)
        {
            await inputPort.HandleDeleteProduct(id);
            return true;
        }
    }
}
    