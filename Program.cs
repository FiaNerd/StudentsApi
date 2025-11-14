using Microsoft.AspNetCore.Http.HttpResults;
using StudentsApi.Models;
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
builder.Services.AddSingleton<ICourseService, CourseService>();

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//app.MapGet("/api/course", (ICourseService courseService) => { 
//    return Results.Ok(courseService.GetAllCourses());
//});

//app.MapGet("/api/course/{id}", (Guid id, ICourseRepository courseRepo) =>
//{
//	try
//	{
//		var courseById = courseRepo.GetCourseById(id);

//		return Results.Ok(courseById);
//    }
//	catch (Exception)
//	{

//		throw;
//	}
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
