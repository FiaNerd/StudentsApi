namespace StudentsApi.Models
{
    public class Grade
    {
        public Guid Id { get; } = Guid.NewGuid();
        public GradeValue GradeValue { get; set; }

        public Grade(GradeValue gradeValue)
        { 
            GradeValue = gradeValue;
        }
    }
}
