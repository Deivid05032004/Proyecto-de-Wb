

namespace Billing.Sales.Backend.IoC
{
    public static class DependencyContainer
    {

    public static IServiceCollection AddBillingSalesServices(this IServiceCollection services,
                                                             Action<DBOptions> configureDb)
        {
            services.AddUseCasesServices()
                .AddRepositories()
                .AddDataContexts(configureDb)
                .AddPresenters();

            return services;
        } 
    }
}
