using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(s => s.SaleId);

            builder.Property(s => s.CustomerId)
                .IsRequired();

            builder.Property(s => s.CustomerName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.SaleNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.SaleDate)
                .IsRequired();

            builder.Property(s => s.TotalAmount)
                .HasColumnType("decimal(18,2)");

            // Mapeia Filial como um Value Object (owned entity)
            builder.OwnsOne(s => s.Filial, filial =>
            {
                filial.Property(f => f.Name).HasColumnName("FilialName"); // Nome da coluna no BD
            });

            builder.Property(s => s.Status)
                .IsRequired();

            builder.HasMany(s => s.Items)
                .WithOne()
                .HasForeignKey("SaleId");

            // Caso mude SaleItem como coleção de Value Objects (Owned)
            /*
            builder.OwnsMany(s => s.Items, item =>
            {
                item.WithOwner().HasForeignKey("SaleId"); // Opcional se SaleId for shadow property
                item.Property(i => i.ProductName).IsRequired();

                // Configura Discount como Value Object dentro de SaleItem
                item.OwnsOne(i => i.Discount, discount =>
                {
                    discount.Property(d => d.Percentage).HasColumnName("DiscountPercentage");
                });
            });
            */

            builder.ToTable("Sales");
        }
    }
}
