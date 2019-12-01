namespace Cinema.Data.ModelsConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Cinema.Data.Models;

    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> customer)
        {
            customer
                .HasKey(c => c.Id);
        }
    }
}
