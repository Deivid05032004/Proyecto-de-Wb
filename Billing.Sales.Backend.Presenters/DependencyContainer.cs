using Billing.Sales.Backend.BusinessObjects.Interfaces.Customers;
using Billing.Sales.Backend.BusinessObjects.Interfaces.OrderDetails;
using Billing.Sales.Backend.BusinessObjects.Interfaces.Orders;
using Billing.Sales.Backend.BusinessObjects.Interfaces.Products;
using Billing.Sales.Backend.Presenters.CustomersPresenters;
using Billing.Sales.Backend.Presenters.OrdersDetailsPresenters;
using Billing.Sales.Backend.Presenters.OrdersPresenters;
using Billing.Sales.Backend.Presenters.ProductPresenters;
using Microsoft.Extensions.DependencyInjection;


namespace Billing.Sales.Backend.Presenters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<IOrderOutputPort, CreateOrderPresenter>();
            services.AddScoped<ICustomerOuputPort, CreateCustomerPresenter>();
            services.AddScoped<IProductOuputPort, CreateProductPresenter>();
            services.AddScoped<IOrderDetailOuputPort, CreateOrderDetailPresenter>();
            //services.AddScoped<IAuthOutputPort, AuthPresenter>();
            // Retornar el contenedor de servicios
            return services;
        }
    }
}
