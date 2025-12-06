using System.Net.Http.Json;
using Billing.Sales.FrontEndCode.Models;

namespace Billing.Sales.FrontEndCode.Services;

public class ProductService
{
    private readonly HttpClient _http;

    public ProductService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<ProductModel>> GetAllAsync()
    {
        return await _http.GetFromJsonAsync<List<ProductModel>>("api/products")
               ?? new List<ProductModel>();
    }

    public async Task<ProductModel?> GetAsync(int id)
    {
        return await _http.GetFromJsonAsync<ProductModel>($"api/products/{id}");
    }

    public async Task<bool> CreateAsync(ProductModel product)
    {
        var response = await _http.PostAsJsonAsync("api/products", product);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateAsync(ProductModel product)
    {
        var response = await _http.PutAsJsonAsync($"api/products/{product.Id}", product);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/products/{id}");
        return response.IsSuccessStatusCode;
    }
}
