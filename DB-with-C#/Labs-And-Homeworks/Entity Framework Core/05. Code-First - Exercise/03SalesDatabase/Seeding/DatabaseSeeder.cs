namespace P03_SalesDatabase.Seeding
{
    using System;
    using Microsoft.EntityFrameworkCore;

    using P03_SalesDatabase.Data.Models;

    public static class DatabaseSeeder
    {
        public static void ProductsSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasData(
                new Product
                {
                    ProductId = 1,
                    Name = "Computer",
                    Quantity = 2,
                    Price = 1650,
                    Description = "Asus ROG GGL552VW"
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Mouse",
                    Quantity = 1,
                    Price = 25,
                    Description = "Gaming mouse for laptop"
                });
        }

        public static void CustomersSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasData(
                new Customer
                {
                    CustomerId = 1,
                    Name = "Pesho",
                    Email = "pesho_peshov@mail.bg",
                    CreditCardNumber = "BG363681HA23"
                },
                new Customer
                {
                    CustomerId = 2,
                    Name = "Stanislav",
                    Email = "slavkata_99@abv.bg",
                    CreditCardNumber = "BGH36368HA40"
                });
        }

        public static void StoresSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>()
                .HasData(
                new Store
                {
                    StoreId = 1,
                    Name = "Techmarket++"
                },
                new Store
                {
                    StoreId = 2,
                    Name = "Technopolis"
                },
                new Store
                {
                    StoreId = 3,
                    Name = "Techworld"
                });
        }

        public static void SalesSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>()
                .HasData(
                new Sale
                {
                    SaleId = 1,
                    Date = DateTime.UtcNow,
                    ProductId = 1,
                    CustomerId = 1,
                    StoreId = 2
                },
                new Sale 
                {
                    SaleId = 2,
                    Date = DateTime.UtcNow,
                    ProductId = 2,
                    CustomerId = 2,
                    StoreId = 1
                });
        }
    }
}
