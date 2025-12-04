using Microsoft.EntityFrameworkCore;
using StudentsApi.Models;

namespace StudentsApi.Persistence
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseInstance> CourseInstances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasData(
                    new Student("One Student", "one@nomail.com") { Id = Guid.Parse("11111111-1111-1111-1111-111111111111") },
                    new Student("Second Student", "two@nomail.com") { Id = Guid.Parse("22222222-2222-2222-2222-222222222222") },
                    new Student("Third Student", "three@nomail.com") { Id = Guid.Parse("33333333-3333-3333-3333-333333333333") }
                );

            modelBuilder.Entity<Course>().HasData(
                new Course("Mathematics", "An introduction to mathematical concepts.") { Id =  Guid.Parse("a1b2c3d4-e5f6-4789-abcd-1234567890ab") },
                new Course("History", "A study of historical events and figures.") { Id = Guid.Parse("b2c3d4e5-f678-489a-bcde-2345678901bc") },
                new Course("Biology", "Exploring the science of life and living organisms.") { Id = Guid.Parse("c3d4e5f6-789a-49ab-cdef-3456789012cd") },
                new Course("IT", "Exploring the internet.") { Id = Guid.Parse("96deb571-e143-4fe7-a54f-eacda657a5a7") }
            );

            modelBuilder.Entity<CourseInstance>()
                .HasData(
                    new CourseInstance(DateTime.Parse("2024-09-01"), DateTime.Parse("2025-06-30"))
                    {
                        Id = Guid.Parse("d4e5f678-9a4b-4bcf-def0-4567890123de"),
                        CourseId = Guid.Parse("a1b2c3d4-e5f6-4789-abcd-1234567890ab")// Mathematics
                    },
                    new CourseInstance(DateTime.Parse("2024-09-01"), DateTime.Parse("2025-06-30"))
                    {
                        Id = Guid.Parse("e5f6789a-4b5c-4cdf-ef01-5678901234ef"),
                        CourseId = Guid.Parse("b2c3d4e5-f678-489a-bcde-2345678901bc") // History
                    },
                    new CourseInstance(DateTime.Parse("2024-09-01"), DateTime.Parse("2025-06-30"))
                    {
                        Id = Guid.Parse("f6789a4b-5c6d-4def-f012-6789012345f0"),
                        CourseId = Guid.Parse("c3d4e5f6-789a-49ab-cdef-3456789012cd") // Biology
                    },
                    new CourseInstance(DateTime.Parse("2024-09-01"), DateTime.Parse("2025-06-30"))
                    {
                        Id = Guid.Parse("a54f96de-b571-4fe7-a54f-eacda657a5a7"),
                        CourseId = Guid.Parse("96deb571-e143-4fe7-a54f-eacda657a5a7") // IT
                    }
                );

            modelBuilder.Entity<Course>()
                .HasMany(c => c.CourseInstances)
                .WithOne(ci => ci.Course)
                .HasForeignKey(ci => ci.CourseId);

            modelBuilder.Entity<CourseInstance>()
                .HasMany(ci => ci.Students)
                .WithMany(s => s.CourseInstances)
                .UsingEntity<Dictionary<string, object>>(
                    "CourseInstanceStudent", // join table name
                    j => j.HasData(
                        new { CourseInstancesId = Guid.Parse("e5f6789a-4b5c-4cdf-ef01-5678901234ef"), StudentsId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
                        new { CourseInstancesId = Guid.Parse("d4e5f678-9a4b-4bcf-def0-4567890123de"), StudentsId = Guid.Parse("22222222-2222-2222-2222-222222222222") },
                        new { CourseInstancesId = Guid.Parse("f6789a4b-5c6d-4def-f012-6789012345f0"), StudentsId = Guid.Parse("33333333-3333-3333-3333-333333333333") },
                          new { CourseInstancesId = Guid.Parse("f6789a4b-5c6d-4def-f012-6789012345f0"), StudentsId = Guid.Parse("11111111-1111-1111-1111-111111111111") }
                    )
                );
        }
    }
}
