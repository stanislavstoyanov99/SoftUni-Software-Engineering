﻿namespace Cinema.Data.ModelsConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Cinema.Data.Models;

    public class ProjectionConfiguration : IEntityTypeConfiguration<Projection>
    {
        public void Configure(EntityTypeBuilder<Projection> projection)
        {
            projection
                .HasOne(p => p.Movie)
                .WithMany(m => m.Projections)
                .HasForeignKey(p => p.MovieId);

            projection
                .HasOne(p => p.Hall)
                .WithMany(h => h.Projections)
                .HasForeignKey(p => p.HallId);
        }
    }
}
