
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Billing.Sales.Backend.DataContext.EFCore.Configurations
{
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.CustomerId)
           .IsRequired();

            builder.Property(o => o.OrderDate)
                .IsRequired()
                .HasColumnType("timestamptz");


            builder.Property(o => o.Total)
                .HasPrecision(10, 2)
                .HasDefaultValue(0);
        }
    }
}
