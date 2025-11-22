
using Microsoft.EntityFrameworkCore;
using StudentsApi.Models;

namespace StudentsApi.Persistence
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Student> Students
        {
            get; set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student("Alice", "no@mail.com") { Id = Guid.Parse("3f9c0dbb-7968-45b1-9dd7-de6b1697b282") },
                    new Student("Bob", "mail@nomail.com") { Id = Guid.Parse("87f9e043-77ab-4001-81ef-45e4c97f6b38") },
                    new Student("Charlie", "nomail@nomail.com") { Id = Guid.Parse("f6304608-f675-4389-80e4-f9a48e17c232") },
                     new Student("Charlie", "nomail@nomail.com") { Id = Guid.Parse("889359d2-4efc-46b1-ae24-f192495d4e05") }
            );
        }
    }
}
