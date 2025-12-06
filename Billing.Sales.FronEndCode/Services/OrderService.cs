using System.Net.Http.Json;
using Billing.Sales.FrontEndCode.Models;

namespace Billing.Sales.FrontEndCode.Services
{
    public class OrderService
    {
        private readonly HttpClient _http;

        public OrderService(HttpClient http)
        {
            _http = http;
        }

        // Obtener todas las ordenes (útil para obtener la última id)
        public async Task<List<OrderModel>> GetAllAsync()
        {
            var list = await _http.GetFromJsonAsync<List<OrderModel>>("api/orders");
            return list ?? new List<OrderModel>();
        }

        // Obtener orden por id
        public async Task<OrderModel?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<OrderModel>($"api/orders/{id}");
        }

        // Crear orden (envía OrderCreateDto)
        public async Task<bool> CreateAsync(OrderCreateDto dto)
        {
            var resp = await _http.PostAsJsonAsync("api/orders", dto);
            return resp.IsSuccessStatusCode;
        }
    }
}
