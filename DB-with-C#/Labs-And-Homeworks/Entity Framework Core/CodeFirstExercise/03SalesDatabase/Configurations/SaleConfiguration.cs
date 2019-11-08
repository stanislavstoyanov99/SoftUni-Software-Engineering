namespace P03_SalesDatabase.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using P03_SalesDatabase.Data.Models;

    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder
                .HasOne(s => s.Product)
                .WithMany(p => p.Sales)
                .HasForeignKey(s => s.ProductId);

            builder
                .HasOne(s => s.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CustomerId);

            builder
                .HasOne(s => s.Store)
                .WithMany(st => st.Sales)
                .HasForeignKey(s => s.StoreId);

            builder
                .Property(p => p.Date)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
