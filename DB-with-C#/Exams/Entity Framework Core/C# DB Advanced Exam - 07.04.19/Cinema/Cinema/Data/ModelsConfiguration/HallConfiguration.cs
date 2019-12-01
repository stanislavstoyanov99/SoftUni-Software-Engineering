namespace Cinema.Data.ModelsConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Cinema.Data.Models;

    public class HallConfiguration : IEntityTypeConfiguration<Hall>
    {
        public void Configure(EntityTypeBuilder<Hall> hall)
        {
            hall
                .HasKey(h => h.Id);
        }
    }
}
