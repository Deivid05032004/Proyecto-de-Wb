using Billing.Sales.Backend.DataContext.EFCore.Options;
using Billing.Sales.Backend.IoC;

namespace Billing.RazorComponent.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // IOC: Binding a DBOptions
            builder.Services.AddBillingSalesServices(options =>
            {
                builder.Configuration
                       .GetSection(DBOptions.SectionKey)
                       .Bind(options);
            });

            // CORS para permitir al Blazor WA conectarse
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            // ? EXPONE TUS ENDPOINTS Minimal API
            app.MapBillingSalesEndPoints();

            // ? Controllers (si usas alguno adicional)
            app.MapControllers();

            app.Run();
        }
    }
}
