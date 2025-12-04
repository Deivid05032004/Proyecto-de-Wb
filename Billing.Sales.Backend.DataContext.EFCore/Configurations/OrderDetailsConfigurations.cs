

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Billing.Sales.Backend.DataContext.EFCore.Configurations
{
    public class OrderDetailsConfigurations : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(d => new { d.OrderId, d.ProductId });
            builder.Property(d => d.UnitPrice).HasPrecision(8, 2);
            builder.Property(d=>d.Quantity).IsRequired();
        }
    }
}
