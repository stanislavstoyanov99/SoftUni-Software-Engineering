namespace P03_FootballBetting.Data.Seeding
{
    using Microsoft.EntityFrameworkCore;

    using P03_FootballBetting.Data.Models;

    public static class DataSeeder
    {
        public static void CountrySeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasData(
                new Country
                {
                    CountryId = 1,
                    Name = "Bulgaria"
                },
                new Country
                {
                    CountryId = 2,
                    Name = "USA"
                },
                new Country
                {
                    CountryId = 3,
                    Name = "Italy"
                });
        }

        public static void TownSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Town>()
                .HasData(
                new Town
                {
                    TownId = 1,
                    CountryId = 1,
                    Name = "Sofia"
                },
                new Town
                {
                    TownId = 2,
                    CountryId = 2,
                    Name = "Los Angelis"
                });
        }

        public static void ColorSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>()
                .HasData(
                new Color
                {
                    ColorId = 1,
                    Name = "Black"
                },
                new Color
                {
                    ColorId = 2,
                    Name = "White"
                },
                new Color
                {
                    ColorId = 3,
                    Name = "Red"
                });
        }

        public static void PositionSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>()
                .HasData(
                new Position
                {
                    PositionId = 1,
                    Name = "attacker"
                },
                new Position
                {
                    PositionId = 2,
                    Name = "deffender"
                });
        }

        // Can be done for all entities to populate database with initial data ...
    }
}
