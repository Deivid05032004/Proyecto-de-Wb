
namespace Billing.Sales.FrontEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplication.CreateBuilder(args)
               .CreateWebApplication()
               .ConfigureWebApplication()
               .Run();
        }
    }
}
