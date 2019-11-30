namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    using P01_StudentSystem.Seeding;
    using P01_StudentSystem.Data.Models;
    using P01_StudentSystem.Configurations;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(DataSettings.DefaultConnection);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Traditional way
            //modelBuilder.ApplyConfiguration(new StudentConfiguration());
            //modelBuilder.ApplyConfiguration(new CourseConfiguration());
            //modelBuilder.ApplyConfiguration(new ResourceConfiguration());
            //modelBuilder.ApplyConfiguration(new HomeworkConfiguration());
            //modelBuilder.ApplyConfiguration(new StudentCourseConfiguration());

            // With Reflection
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            DatabaseSeeder.StudentsSeed(modelBuilder);
            DatabaseSeeder.HomeworkSubmissionsSeed(modelBuilder);
            DatabaseSeeder.CoursesSeed(modelBuilder);
            DatabaseSeeder.ResourcesSeed(modelBuilder);
            DatabaseSeeder.StudentCourseSeed(modelBuilder);
        }
    }
}
