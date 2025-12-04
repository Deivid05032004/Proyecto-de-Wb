

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Billing.Sales.Backend.DataContext.EFCore.Configurations
{
    public class ProductsConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
           .IsRequired()
           .HasMaxLength(100);

            // Marca del producto
            builder.Property(p => p.Brand)
                .IsRequired()
                .HasMaxLength(50);
            // Presentación del producto
            builder.Property(p => p.Presentation)
                .IsRequired()
                .HasMaxLength(100);

            // Precio unitario
            builder.Property(p => p.Price)
                .IsRequired()
                .HasPrecision(10, 2)
                .HasDefaultValue(0);

            // Stock
            builder.Property(p => p.Stock)
                .IsRequired()
                .HasDefaultValue(0);
        }
    }
}
