namespace BookShop.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using BookShop.Models;

    internal class BookCategoryConfiguration : IEntityTypeConfiguration<BookCategory>
    {
        public void Configure(EntityTypeBuilder<BookCategory> builder)
        {
            builder.HasKey(bk => new { bk.BookId, bk.CategoryId });

            builder
                .HasOne(bk => bk.Book)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(bk => bk.BookId);

            builder
                .HasOne(bk => bk.Category)
                .WithMany(c => c.CategoryBooks)
                .HasForeignKey(bk => bk.CategoryId);
        }
    }
}
