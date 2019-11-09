namespace P01_StudentSystem.Seeding
{
    using System;
    using Microsoft.EntityFrameworkCore;

    using P01_StudentSystem.Data.Enumerations;
    using P01_StudentSystem.Data.Models;

    public static class DatabaseSeeder
    {
        public static void StudentsSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasData(
                new Student
                {
                    StudentId = 1,
                    Birthday = DateTime.UtcNow,
                    Name = "Pesho",
                    PhoneNumber = "0884034665",
                    RegisteredOn = DateTime.UtcNow.AddDays(-10)
                },
                new Student
                {
                    StudentId = 2,
                    Birthday = DateTime.UtcNow.AddDays(-200),
                    Name = "Kiril",
                    PhoneNumber = "0884034667",
                    RegisteredOn = DateTime.UtcNow.AddDays(-100)
                });
        }

        public static void CoursesSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasData(
                new Course
                {
                    CourseId = 1,
                    Name = "C# OOP",
                    Description = "C# OOP Module",
                    EndDate = DateTime.UtcNow,
                    StartDate = DateTime.UtcNow.AddDays(-30),
                    Price = 350,
                },
                new Course
                {
                    CourseId = 2,
                    Name = "C# Advanced",
                    Description = "C# Advanced Module",
                    EndDate = DateTime.UtcNow,
                    StartDate = DateTime.UtcNow.AddDays(-40),
                    Price = 400,
                },
                new Course
                {
                    CourseId = 3,
                    Name = "Java Web",
                    Description = "Java Web Module",
                    EndDate = DateTime.UtcNow,
                    StartDate = DateTime.UtcNow.AddDays(-50),
                    Price = 500,
                }
                );
        }

        public static void ResourcesSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>()
                .HasData(
                new Resource
                {
                    ResourceId = 1,
                    CourseId = 1,
                    Name = "SoftUni",
                    ResourceType = ResourceType.Document,
                    Url = "softuni.bg"
                },
                new Resource
                {
                    ResourceId = 2,
                    CourseId = 2,
                    Name = "Telerik Academy",
                    ResourceType = ResourceType.Video,
                    Url = "telerik.bg"
                },
                new Resource
                {
                    ResourceId = 3,
                    CourseId = 3,
                    Name = "Tech world",
                    ResourceType = ResourceType.Presentation,
                    Url = "techworld.com"
                },
                new Resource
                {
                    ResourceId = 4,
                    CourseId = 2,
                    Name = "Tech world and future technologies",
                    ResourceType = ResourceType.Other,
                    Url = "techworldfuturetechnologies.com"
                });
        }

        public static void HomeworkSubmissionsSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Homework>()
                .HasData(
                new Homework
                {
                    HomeworkId = 1,
                    Content = "Some content here",
                    ContentType = ContentType.Application,
                    CourseId = 1,
                    StudentId = 1,
                    SubmissionTime = DateTime.UtcNow
                },
                new Homework
                {
                    HomeworkId = 2,
                    Content = "Some content here 2",
                    ContentType = ContentType.Pdf,
                    CourseId = 2,
                    StudentId = 1,
                    SubmissionTime = DateTime.UtcNow
                },
                new Homework
                {
                    HomeworkId = 3,
                    Content = "Some content here 3",
                    ContentType = ContentType.Zip,
                    CourseId = 2,
                    StudentId = 2,
                    SubmissionTime = DateTime.UtcNow
                });
        }

        public static void StudentCourseSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasData(
                new StudentCourse
                {
                    StudentId = 1,
                    CourseId = 1
                },
                new StudentCourse
                {
                    StudentId = 2,
                    CourseId = 2
                });
        }
    }
}
