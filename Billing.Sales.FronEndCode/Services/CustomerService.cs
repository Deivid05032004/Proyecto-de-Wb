using Billing.Sales.FrontEndCode.Models;
using System.Net.Http.Json;

namespace Billing.Sales.FrontEndCode.Services
{
    public class CustomerService
    {
        private readonly HttpClient _http;

        public CustomerService(HttpClient http)
        {
            _http = http;
        }

        public Task<List<CustomerModel>> GetAllAsync() =>
            _http.GetFromJsonAsync<List<CustomerModel>>("api/customers");

        public Task<CustomerModel?> GetByIdAsync(int id) =>
            _http.GetFromJsonAsync<CustomerModel>($"api/customers/{id}");

        public async Task CreateAsync(CustomerModel model) =>
            await _http.PostAsJsonAsync("api/customers", model);

        public async Task UpdateAsync(CustomerModel model) =>
            await _http.PutAsJsonAsync($"api/customers/{model.Id}", model);

        public async Task DeleteAsync(int id) =>
            await _http.DeleteAsync($"api/customers/{id}");
    }
}
