using Billing.Sales.Backend.BusinessObjects.Interfaces.Products;

namespace Billing.Sales.Backend.UseCases.ProductInteractor
{
    public class CreateProductInteractor(IProductOuputPort ouputPort, ICommandsProductRepository repository) : IProductInputPort
    {
        public async Task HandleCreateProduct(CreateProductDto productdto)
        {
            var product = ProductAggregate.CresteProductFrom(productdto);
            await repository.CreateProduct(product);
            await repository.SaveChanges();
            await ouputPort.PresentProductCreated(product);
        }

        public async Task HandleDeleteProduct(int productId)
        {
            var product = await repository.GetProductById(productId);
            
            if (product == null) 
            {
                await ouputPort.PresentProductDeleted(productId);
                return;
            }
            await repository.DeleteProduct(product);
            await repository.SaveChanges();
            await ouputPort.PresentProductDeleted(productId);
        }

        public async Task HandleGetAllProducts()
        {
            var product = await repository.GetAllProducts();
            ouputPort.productsList = product;
            
            await ouputPort.PresentAllProducts();
            
        }

        public async Task HandleGetProductById(int productId)
        {
            var product = await repository.GetProductById(productId);
            ouputPort.ProductById = product;
            await ouputPort.PresentProduct(product);
        }

        public async Task HandleUpdateProduct(int productId, CreateProductDto productdto)
        {
            var product = await repository.GetProductById(productId);

            if (product == null) 
            {
                await ouputPort.PresentProductUpdated(productId, null);
                return;
            }

            if (product is ProductAggregate aggregate)
                aggregate.UpdateProductFrom(productdto);
            else
                throw new Exception("Error al cargar los datos del producto");

            await repository.SaveChanges();

            await ouputPort.PresentProductUpdated(productId,product);
        }
    }
}
