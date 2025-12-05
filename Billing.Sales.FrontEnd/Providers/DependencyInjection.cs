using Billing.Sales.FrontEnd.Services;

namespace Billing.Sales.FrontEnd.Providers
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddFrontendServices(this IServiceCollection services)
        {
            services.AddScoped<CustomerService>();
            return services;
        }
    }
}
