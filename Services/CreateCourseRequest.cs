namespace StudentsApi.Services
{
    public struct CreateCourseRequest (string title, string description)
    {
        public string Title { get; set; } = title;
        public string Description { get; set; } = description;
    }
}
