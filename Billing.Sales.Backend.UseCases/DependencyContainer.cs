

using Billing.Sales.Backend.BusinessObjects.Interfaces.Orders;
using Billing.Sales.Backend.BusinessObjects.Interfaces.Products;
using Billing.Sales.Backend.UseCases.CustoerInteractor;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Billing.Sales.Backend.UseCases;

public static class DependencyContainer
{
    public static IServiceCollection AddUseCasesServices(this IServiceCollection services) 
    {
        // Customers
        services.AddScoped<ICustomerInputPort, CreateCustomerInteractor>();
        //services.AddScoped<ICustomerOuputPort>, CustomerPresenter();
        services.AddScoped<ICommandsCustomerRepository, ICommandsCustomerRepository>();

        //PRODUCTS
        services.AddScoped<IProductInputPort, CreateProductInteractor>();
        //services.AddScoped<IProductOuputPort, ProductPresenter>();
        services.AddScoped<ICommandsProductRepository, ICommandsProductRepository>();

        //ORDERS
        services.AddScoped<IOrderInputPort, CreateOrderInteractor>();
        //services.AddScoped<IProductOuputPort, OrderPresenter>();
        services.AddScoped<ICommandsOrderRepository, ICommandsOrderRepository>();

        return services;
    }
}
