namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using P03_FootballBetting.Data.Models;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);

            builder
                .Property(u => u.Username)
                .IsRequired(true)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder
                .Property(u => u.Password)
                .IsRequired(true)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder
                .Property(u => u.Email)
                .IsRequired(true)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder
                .Property(u => u.Name)
                .IsRequired(true)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder
                .Property(u => u.Balance)
                .IsRequired(true);
        }
    }
}
