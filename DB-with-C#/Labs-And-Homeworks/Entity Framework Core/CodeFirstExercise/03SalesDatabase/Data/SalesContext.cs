namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;

    using P03_SalesDatabase.Configurations;
    using P03_SalesDatabase.Data.Models;
    using P03_SalesDatabase.Seeding;

    public class SalesContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(DataSettings.DefaultConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SaleConfiguration());

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());

            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            DatabaseSeeder.ProductsSeed(modelBuilder);
            DatabaseSeeder.CustomersSeed(modelBuilder);
            DatabaseSeeder.StoresSeed(modelBuilder);
            DatabaseSeeder.SalesSeed(modelBuilder);
        }
    }
}
