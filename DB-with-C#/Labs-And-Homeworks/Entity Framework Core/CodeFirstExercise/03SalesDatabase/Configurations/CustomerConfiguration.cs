namespace P03_SalesDatabase.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using P03_SalesDatabase.Data.Models;

    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .Property(p => p.Email)
                .IsUnicode(false);
        }
    }
}
