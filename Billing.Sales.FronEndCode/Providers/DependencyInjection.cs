using Billing.Sales.FrontEndCode.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Billing.Sales.FrontEndCode.Providers
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddFrontendServices(this IServiceCollection services)
        {
            services.AddScoped<CustomerService>();
            services.AddScoped<ProductService>();
            services.AddScoped<OrderService>();

            return services;
        }
    }
}
