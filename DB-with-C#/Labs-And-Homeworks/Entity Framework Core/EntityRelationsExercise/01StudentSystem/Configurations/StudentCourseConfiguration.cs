﻿namespace P01_StudentSystem.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using P01_StudentSystem.Data.Models;

    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            //Relationships
            builder.HasKey(sc => new { sc.StudentId, sc.CourseId });

            builder
                .HasOne(sc => sc.Student)
                .WithMany(s => s.CourseEnrollments)
                .HasForeignKey(sc => sc.StudentId);

            builder
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentsEnrolled)
                .HasForeignKey(sc => sc.CourseId);
        }
    }
}
