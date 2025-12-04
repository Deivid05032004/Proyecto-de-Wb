
namespace Billing.Sales.Backend.DataContext.EFCore.DataContext;
internal class BillingSalesContext(IOptions<DBOptions> dbOptions) : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    public DbSet<Product> Product { get; set; }
    public DbSet<Customer> Customer { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(dbOptions.Value.ConnectionString);

        }
    }

    // Permite a las herramientas de Entity Framework Core aplicar la configuración de las entidades.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }


}