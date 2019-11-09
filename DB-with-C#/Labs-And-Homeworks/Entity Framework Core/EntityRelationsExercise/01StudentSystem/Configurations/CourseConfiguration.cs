namespace P01_StudentSystem.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using P01_StudentSystem.Data.Models;

    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.CourseId);

            builder
                .Property(c => c.Name)
                .IsRequired(true)
                .HasMaxLength(80)
                .IsUnicode(true);

            builder
                .Property(c => c.Description)
                .IsRequired(false)
                .IsUnicode(true);
        }
    }
}
