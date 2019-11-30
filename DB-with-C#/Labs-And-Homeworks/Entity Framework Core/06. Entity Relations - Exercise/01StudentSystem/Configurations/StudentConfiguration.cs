namespace P01_StudentSystem.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using P01_StudentSystem.Data.Models;

    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.StudentId);

            builder
                .Property(s => s.Name)
                .IsRequired(true)
                .HasMaxLength(100)
                .IsUnicode(true);

            builder
                .Property(s => s.PhoneNumber)
                .IsRequired(false)
                .HasColumnType("char(10)")
                .IsUnicode(false);

            builder
                .Property(s => s.Birthday)
                .HasColumnType("DATETIME2")
                .IsRequired(false);
        }
    }
}
