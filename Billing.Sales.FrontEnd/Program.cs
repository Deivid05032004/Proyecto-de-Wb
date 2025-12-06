using Billing.Sales.FrontEnd;
using Billing.Sales.FrontEnd.Providers;

var builder = WebApplication.CreateBuilder(args);

// Agrega soporte a Razor Components (Blazor Server)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Registrar HttpClient para consumir tu API
builder.Services.AddHttpClient("Backend", client =>
{
    client.BaseAddress = new Uri("https://localhost:5001/"); // AJUSTA A TU API REAL
});
builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IHttpClientFactory>().CreateClient("Backend"));

// Registrar servicios personalizados
builder.Services.AddFrontendServices();

var app = builder.Build();

app.UseStaticFiles();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();