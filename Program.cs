using StudentsApi.Repositories;
using StudentsApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.AddSingleton<IStudentRepository, StudentRepository>();
builder.Services.AddSingleton<ICourseRepository, CourseRepository>();
builder.Services.AddSingleton<IStudentService, StudentService>();

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/api/course", (ICourseRepository courseRepo) => { 
    return Results.Ok(courseRepo.GetAllCourses());
});

app.MapGet("/api/course/{id}", (Guid id, ICourseRepository courseRepo) =>
{
	try
	{
		var courseById = courseRepo.GetCourseById(id);

		return Results.Ok(courseById);
    }
	catch (Exception)
	{

		throw;
	}
});

app.Run();
