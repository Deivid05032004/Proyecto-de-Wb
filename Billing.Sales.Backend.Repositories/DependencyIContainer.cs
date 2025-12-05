

using Billing.Sales.Backend.BusinessObjects.Interfaces.Repositories;
using Billing.Sales.Backend.Repositories.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Billing.Sales.Backend.Repositories
{
    public static class DependencyIContainer
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICommandsOrderRepository, OrderCommandsRepository>();
            services.AddScoped<ICommandsCustomerRepository, CustomerCommandsRepository>();
            services.AddScoped<ICommandsProductRepository, ProductCommandsRepository>();
            services.AddScoped<ICommandsOrderDetailsRepository, OrderDetailCommandsRepository>();
            //services.AddScoped<ICommandsOrderDetailsRepository, CommandsOrderDetailRepository>();

            // services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
