
namespace Billing.Sales.Fronend.Gateways.CustomerGateway
{
    public class CreateCustomerGateway(HttpClient cliente) : ICustomerGateway
    {
        public async Task<int> createCustomerAsync(CreateCustomerDto customerDto)
        {
            int customerId = 0;
            var response = await cliente.PostAsJsonAsync(EndPoints.Customers, customerDto);
            if (response.IsSuccessStatusCode) 
            {
                customerId=await response.Content.ReadFromJsonAsync<int>();
            }
            return customerId;
        }

        public async Task DeleteCustomerByIdAsync(int id)
        {
            var url = EndPoints.CustomersById.Replace("{id}", id.ToString());

            var response = await cliente.DeleteAsync(url);
            if (!response.IsSuccessStatusCode) 
            {
                throw new Exception("Error al eliminar el cliente.");
            }

        }

        public async Task<IEnumerable<CreateCustomerDto>> GetAllCustomersAsync()
        {
            var response = await cliente.GetAsync(EndPoints.Customers);
            if (!response.IsSuccessStatusCode) 
            {
                return Enumerable.Empty<CreateCustomerDto>();
            }
            return await response.Content.ReadFromJsonAsync<IEnumerable<CreateCustomerDto>>();
        }

        public async Task<CreateCustomerDto> GetCustomerByIdAsync(int id)
        {
            var url = EndPoints.CustomersById.Replace("{id}",id.ToString());

            var response = await cliente.GetAsync(url);
            if (!response.IsSuccessStatusCode) 
            {
                return null;
            }
            return await response.Content.ReadFromJsonAsync <CreateCustomerDto>();
        }

        public async Task updateCustomerAsync(int CustomerId, CreateCustomerDto customerDto)
        {
            var url = EndPoints.CustomersById.Replace("{id}", CustomerId.ToString());

            var response = await cliente.PutAsJsonAsync(url, customerDto);
            if (!response.IsSuccessStatusCode) 
            {
                throw new Exception("Error al actualizar el cliente.");
            }

        }
    }
}