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
builder.Services.AddSingleton<IStudentService, StudentService>();

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/api/student", (CreateStudentRequest newStudent, IStudentService studentService) =>
{
    try
    {
        var createdStudent = studentService.CreateStudent(newStudent);

        return Results.Created($"/api/student/{createdStudent.Id}", createdStudent);
    }
    catch (Exception ex)
    {
        return Results.Problem("An error occurred while adding the student.");
    }
});

app.MapPut("/api/student/{id}", (Guid id, CreateStudentRequest studentRequest, IStudentService studentService) => {
    try
    {
        var updatedStudent = studentService.UpdateStudent(id, studentRequest);

        return Results.Ok(updatedStudent);
    }
    catch 
    {

        throw;
    }
});

app.Run();
