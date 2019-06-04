using Microsoft.EntityFrameworkCore;
using BandRegister.Models;

namespace BandRegister.Data
{
    public class BandRegisterDbContext : DbContext
    {
        public DbSet<Band> Bands { get; set; }

        private const string ConnectionString = @"Server=.\SQLEXPRESS;Database=BandsDb;Integrated Security=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
