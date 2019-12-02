namespace Cinema.Data.ModelsConfiguration
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Cinema.Data.Models;

    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> movie)
        {
            movie
                .HasKey(m => m.Id);
        }
    }
}
