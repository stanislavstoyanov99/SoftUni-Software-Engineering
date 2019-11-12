namespace BookShop.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using BookShop.Models;

    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.BookId);

            builder
                .Property(b => b.Title)
                .IsRequired(true)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder
                .Property(b => b.Description)
                .IsRequired(true)
                .HasMaxLength(1000)
                .IsUnicode(true);

            builder
                .Property(b => b.ReleaseDate)
                .IsRequired(false)
                .HasColumnType("DATETIME2");

            builder
                .Property(b => b.Copies)
                .IsRequired(true);

            builder
                .Property(b => b.Price)
                .IsRequired(true);

            builder
                .Property(b => b.EditionType)
                .IsRequired(true);

            builder
                .Property(b => b.AgeRestriction)
                .IsRequired(true);

            builder
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);
        }
    }
}
