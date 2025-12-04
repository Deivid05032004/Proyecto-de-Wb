using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Sales.Backend.DataContext.EFCore.Configurations
{
    public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c=>c.IdentificationNumber).
                IsRequired().HasMaxLength(10);

            builder.Property(c => c.FirstName)
              .IsRequired()
              .HasMaxLength(100);

            // Apellido
            builder.Property(c => c.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(c => c.Address).
                IsRequired().
                HasMaxLength(50);

            builder.Property(c=>c.EmailAddress).
                IsRequired().
                HasMaxLength(50);
            builder.Property(c=> c.PhoneNumber).
                IsRequired().HasMaxLength(10);

            builder.Property(c=>c.City).
                IsRequired().HasMaxLength(30);
        }
    }
}
