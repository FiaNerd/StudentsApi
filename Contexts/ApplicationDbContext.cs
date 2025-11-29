using Microsoft.EntityFrameworkCore;
using StudentsApi.Models;

namespace StudentsApi.Persistence
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student("Arne", "no@mail.com") { Id = Guid.Parse("3f9c0dbb-7968-45b1-9dd7-de6b1697b282") },
                    new Student("Bo", "mail@nomail.com") { Id = Guid.Parse("87f9e043-77ab-4001-81ef-45e4c97f6b38") },
                    new Student("Charlie", "nomail@nomail.com") { Id = Guid.Parse("f6304608-f675-4389-80e4-f9a48e17c232") },
                     new Student("Jon", "jon@nomail.com") { Id = Guid.Parse("889359d2-4efc-46b1-ae24-f192495d4e05") }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course("Mathematics", "An introduction to mathematical concepts.") { Id = Guid.Parse("a1b2c3d4-e5f6-4789-abcd-1234567890ab") },
                new Course("History", "A study of historical events and figures.") { Id = Guid.Parse("b2c3d4e5-f678-489a-bcde-2345678901bc") },
                new Course("Biology", "Exploring the science of life and living organisms.") { Id = Guid.Parse("c3d4e5f6-789a-49ab-cdef-3456789012cd") },
                new Course("IT", "Exploring the internet.") { Id = Guid.Parse("96deb571-e143-4fe7-a54f-eacda657a5a7") }
            );
        }
    }
}
