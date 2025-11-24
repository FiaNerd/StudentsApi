using System.ComponentModel.DataAnnotations;

public class Course
{
    public Guid Id { get; init; } = Guid.NewGuid();

    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }

    // EF Core needs this
    public Course() { }

    // Convenience constructor
    public Course(string title, string description)
    {
        Title = title;
        Description = description;
    }
}