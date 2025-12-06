using Billing.Sales.FrontEndCode;
using Billing.Sales.FrontEndCode.Providers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Billing.Sales.FrontEndCode
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            // HttpClient conectado al backend real
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7103/")   // ? PUERTO CORRECTO
            });

            // Registrar los servicios del Frontend
            builder.Services.AddFrontendServices();

            await builder.Build().RunAsync();
        }
    }
}
