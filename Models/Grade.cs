namespace StudentsApi.Models
{
    public class Grade (GradeValue value)
    {
        public Guid Id { get; } = Guid.NewGuid();
        public GradeValue Value { get; set; } = value;
    }

    public enum GradeValue
    {
        A,
        B,
        C,
        D,
        F
    }
}
