namespace DemoApp
{
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-ANG7ES6\SQLEXPRESS; Database=DemoApp; Integrated Security=True");
            }
            else
            {
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Tweet> Tweets { get; set; }
    }
}
