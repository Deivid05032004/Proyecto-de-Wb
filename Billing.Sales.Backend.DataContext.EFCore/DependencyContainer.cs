

using Billing.Sales.Backend.DataContext.EFCore.Services;
using Billing.Sales.Backend.DataContext.EFCore.Services.CustomerService;
using Billing.Sales.Backend.Repositories.Interfaces.CustomerCommand;
using Billing.Sales.Backend.Repositories.Interfaces.OrderCommand;
using Billing.Sales.Backend.Repositories.Interfaces.OrderDetailCommand;

namespace Billing.Sales.Backend.DataContext.EFCore
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDataContexts(this IServiceCollection services, Action<DBOptions> configureDBOptions)
        
        {
            services.AddScoped<IOrderBillingSalesCommandDataContext, OrderBillingSalesCommandsDataContext>();
            services.AddScoped<ICustomerBillingSalesCommandDataContext, CustomerBillingSalesCommandsDataContext>();
            services.AddScoped<IProductBillingSalesCommandDataContext, ProductBillingSalesCommandsDataContext>();
            services.AddScoped<IOrderDetailBillingSalesCommandDataContext, OrderDetailBillingSalesCommandsDataContext>();

            // ======== REGISTRO DE REPOSITORIOS =========
            services.AddScoped<ICommandsOrderRepository, OrderCommandsRepository>();
            services.AddScoped<ICommandsCustomerRepository, CustomerCommandsRepository>();
            services.AddScoped<ICommandsProductRepository, ProductCommandsRepository>();
            services.AddScoped<ICommandsOrderDetailsRepository, OrderDetailCommandsRepository>();

            services.Configure(configureDBOptions);
            //services.AddScoped<ICommandsOrderRepository, OrderCommandsRepository>();
            //services.AddScoped<ICommandsCustomerRepository, CustomerCommandsRepository>();
            //services.AddScoped<ICommandsProductRepository, ProductCommandsRepository>();
            //services.AddScoped<ICommandsOrderDetailsRepository, OrderDetailCommandsRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }


    }

}
