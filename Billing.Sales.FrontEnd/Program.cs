
namespace Billing.Sales.FrontEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ?? Agregar servicios necesarios para Blazor Server
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            // ?? Registrar servicio http para consumir la API Backend
            builder.Services.AddHttpClient("BackendApi", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7077"); // <-- cambia a tu API real
            });

            // Si tienes servicios de negocio del frontend aquí se registran:
            // builder.Services.AddScoped<CustomerService>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();

            // ?? Este es el punto de entrada principal de la interfaz Blazor
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            // ?? Arrancar
            app.Run();
        }
    }
    
}
