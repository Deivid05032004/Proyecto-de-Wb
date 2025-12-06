using Billing.Sales.Backend.Contollers.CreateOrder;
using Billing.Sales.Backend.Contollers.CreateOrderDetail;
using Billing.Sales.Backend.Contollers.CreateProduct;
using Billing.Sales.Backend.Controllers.CreateCustomer;
using Microsoft.AspNetCore.Builder;


namespace Billing.Sales.Backend.IoC
{
    public static class EndpointsContainer
    {
        public static WebApplication MapBillingSalesEndPoints(this WebApplication app)
        {
            app.UseCustomersController();
            app.UseOrderController();
            app.UseOrderDetailsController();
            app.UseProductsController();
            return app;
        }
    }
}
