using System.ComponentModel.DataAnnotations;

public class Course(string title, string description)
{
    public Guid Id { get; init; } = Guid.NewGuid();

    [Required]
    public string Title { get; set; } = title;

    [Required]
    public string Description { get; set; } = description;
}
