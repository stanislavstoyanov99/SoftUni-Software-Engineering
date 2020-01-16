namespace Cinema.Data
{
    using System.Linq;
    using System.Reflection;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.EntityFrameworkCore;

    using Cinema.Data.Models;
    using System.Collections.Generic;

    public class CinemaContext : DbContext
    {
        public CinemaContext() 
        {

        }

        public CinemaContext(DbContextOptions options)
            : base(options)   
        {
        
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Hall> Halls { get; set; }

        public DbSet<Projection> Projections { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Seat> Seats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}