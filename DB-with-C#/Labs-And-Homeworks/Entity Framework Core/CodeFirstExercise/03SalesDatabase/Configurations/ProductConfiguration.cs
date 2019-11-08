namespace P03_SalesDatabase.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using P03_SalesDatabase.Data.Models;

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .Property(p => p.Description)
                .IsRequired(false)
                .IsUnicode(true)
                .HasDefaultValue("No description");
        }
    }
}
