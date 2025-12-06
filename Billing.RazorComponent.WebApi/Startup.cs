using Billing.Sales.Backend.Contollers.CreateOrder;
using Billing.Sales.Backend.Contollers.CreateOrderDetail;
using Billing.Sales.Backend.Contollers.CreateProduct;
using Billing.Sales.Backend.Controllers.CreateCustomer;
using Billing.Sales.Backend.DataContext.EFCore.Options;
using Billing.Sales.Backend.IoC;

namespace Billing.Sales.FrontEnd
{
    public static class Startup
    {
        public static WebApplication CreateWebApplication(this WebApplicationBuilder builder)
        {
            // ======================================
            // Swagger
            // ======================================
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // ======================================
            // Controllers (Clean Architecture)
            // ======================================
            builder.Services
                .AddControllers()
                .AddApplicationPart(typeof(CustomersController).Assembly)
                .AddApplicationPart(typeof(OrdersController).Assembly)
                .AddApplicationPart(typeof(ProductController).Assembly)
                .AddApplicationPart(typeof(OrderDetailController).Assembly)
                .AddControllersAsServices();

            // ======================================
            // Clean Architecture IoC registration
            // ======================================
            builder.Services.AddBillingSalesServices(dbOptions =>
                builder.Configuration
                    .GetSection(DBOptions.SectionKey)
                    .Bind(dbOptions));

            // ======================================
            // CORS
            // ======================================
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(config =>
                {
                    config.AllowAnyOrigin();
                    config.AllowAnyHeader();
                    config.AllowAnyMethod();
                });
            });

            return builder.Build();
        }

        public static WebApplication ConfigureWebApplication(this WebApplication app)
        {
            // Swagger
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Middlewares
            app.UseHttpsRedirection();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();

            // ======================================
            // 🔥 REGISTRO DE TUS ENDPOINTS CUSTOM
            // ======================================
            app.MapBillingSalesEndPoints();

            // Controllers tradicionales
            app.MapControllers();

            return app;
        }
    }
}
