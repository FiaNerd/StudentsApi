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

//app.MapPut("/api/student/{id}", (Guid id, Student updatedStudent, IStudentRepository studentRepo) =>
//{
//    var existingStudent = studentRepo.GetStudentById(id);

//    if (existingStudent == null)
//    {
//        return Results.NotFound();
//    }

//    existingStudent.Name = updatedStudent.Name;
//    existingStudent.Email = updatedStudent.Email;

//    var updatedEntity = studentRepo.UpdateStudent(id, existingStudent); 
//    return Results.Ok(updatedEntity);
//});

app.MapDelete("/api/student/{id}", (Guid id, IStudentRepository studentRepo) => { 
    var student = studentRepo.GetStudentById(id);
    if (student == null)
    {
        return Results.NotFound();
    }

    studentRepo.DeleteStudent(id);

    return Results.NoContent();
});

app.Run();
