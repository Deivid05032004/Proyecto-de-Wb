


namespace Billing.Sales.Fronend.Gateways.ProductGateway
{
    public class CreateProductGateway(HttpClient client) : IProductGateway
    {
        public async Task<int> CreateProductAsync(CreateProductDto productDto)
        {
            var idProduct = 0;
            var responde = await client.PostAsJsonAsync(EndPoints.Products, productDto);
            if (responde.IsSuccessStatusCode) 
            {
                idProduct = await responde.Content.ReadFromJsonAsync<int>();
            }
            return idProduct;
        }

        public async Task DeleteProductAsync(int id)
        {
            var url = EndPoints.ProductsById.Replace("{id}",id.ToString());

            var response = await client.DeleteAsync(url);
            if(!response.IsSuccessStatusCode)
            {
                throw new Exception("Error al eliminar el producto");
            }
        }

        public async Task<IEnumerable<CreateProductDto>> GetAllProductsAsyncs()
        {
            var response = await client.GetAsync(EndPoints.Products);
            if (!response.IsSuccessStatusCode) 
            {
                return Enumerable.Empty<CreateProductDto>();
               
            }
            return await response.Content.ReadFromJsonAsync<IEnumerable<CreateProductDto>>();
        }

        public async Task<CreateProductDto> GetProductById(int id)
        {
            var url = EndPoints.ProductsById.Replace("{id}", id.ToString());

            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode) 
            {
                return null;
            }
            return await response.Content.ReadFromJsonAsync<CreateProductDto>(); 
        }

        public async Task UpdateProductAsync(int idProduct, CreateProductDto productDto)
        {
            var url = EndPoints.ProductsById.Replace("{id}", idProduct.ToString());

            var response = await client.PutAsJsonAsync(url, productDto);
            if (!response.IsSuccessStatusCode) 
            {
                throw new Exception("Error al actualizar el producto");
            }
            
        }
    }
}
