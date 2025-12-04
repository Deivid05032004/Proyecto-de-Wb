using Billing.Sales.Backend.BusinessObjects.Interfaces.Repositories;
using Billing.Sales.Backend.Repositories.Interfaces;
using Billing.Sales.Backend.Repositories.Interfaces.ProductCommand;
using Billing.Sales.Backend.Repositories.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Billing.Sales.Backend.DataContext.EFCore
{
    public static class DependencyContainer
    {
        public static IServiceCollection addRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICommandsOrderRepository, OrderCommandsRepository>();
            services.AddScoped<ICommandsCustomerRepository, CustomerCommandsRepository>();
            services.AddScoped<ICommandsProductRepository, ProductCommandsRepository>();
            services.AddScoped<ICommandsOrderDetailsRepository, OrderDetailCommandsRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }


    }

}
