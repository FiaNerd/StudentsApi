using Microsoft.EntityFrameworkCore;
using StudentsApi.Persistence;
using StudentsApi.Repositories;
using StudentsApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseInMemoryDatabase("StudentDb")
    );

builder.Services.AddControllers();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
//builder.Services.AddSingleton<ICourseInstanceRepository, CourseInstanceRepository>();

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ICourseService, CourseService>();

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//app.MapGet("/api/course-instance", (ICourseInstanceRepository courseRepo) =>
//{
//    var courseInstances = courseRepo.GetAllCourseInstance()
//        .Select(ci => new
//        {
//            ci.Id,
//            ci.StartDate,
//            ci.EndDate
//        });

//    return Results.Ok(courseInstances);
//});

//app.MapGet("/api/student/{id}/courses", (Guid id, ICourseInstanceRepository courseInstanceRepo) =>
//{
//    var courses = courseInstanceRepo.GetCoursesByStudent(id)
//        .Select(ci => ci.Course);

//    return Results.Ok(courses);
//});

//app.MapPost("/api/course",(CreateCourseRequest courseRequest, ICourseService courseService) => {
//	try
//	{
//		var addCourse = courseService.CreateCourse(courseRequest);

//		return Results.Created("/api/course", addCourse);
//    }
//	catch (Exception)
//	{

//		throw;
//	}
//});

//app.MapPut("/api/course/{id}", (Guid id, CreateCourseRequest courseRequest, ICourseService courseService) => {
//	try
//	{
//		var updateCourse = courseService.UpdateCourse(id, courseRequest);

//		if (updateCourse is not null)
//		{ 
//			updateCourse.Title = courseRequest.Title;
//			updateCourse.Description = courseRequest.Description;
//        }

//        return Results.Ok(updateCourse);
//    }
//	catch (Exception)
//	{

//		throw;
//	}
//});

//app.MapDelete("/api/course/{id}", (Guid id, ICourseService courseService) => {

//	var deleteCourse = courseService.DeleteCourse(id);

//	if (deleteCourse is not null)
//	{ 
//		return Results.NoContent();
//    }

//    throw new Exception("Course not found");
//});

app.Run();
