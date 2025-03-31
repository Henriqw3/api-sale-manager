using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.HasKey(si => si.ItemId);

            builder.Property(si => si.ProductId)
                .IsRequired(false);

            builder.Property(si => si.ProductName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(si => si.Quantity)
                .IsRequired();

            builder.Property(si => si.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(si => si.TotalAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.OwnsOne(si => si.Discount, discount =>
            {
                discount.Property(d => d.Percentage)
                    .IsRequired()
                    .HasColumnType("decimal(5,2)");
            });

            builder.Property(si => si.Total)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
        }
    }
}
