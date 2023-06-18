using Application.Students.Commands;
using Application.Students.Queries;
using Domain.Models;
using MediatR;
using MinimalApi.Abstractions;
using MinimalApi.Filiters;

namespace MinimalApi.EndpointDefinitions
{
    public class StudentEndpointDefinition : IEndpointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
            var post = app.MapGroup("/api/students");
            post.MapGet("/{id}", GetStudentById)
                .WithName("GetStudentById");
            post.MapPost("/", CreateStudent)
                .AddEndpointFilter<StudentValidationFilters>();
            post.MapGet("/", GetAllStudents);
            post.MapPut("/{id}", UpdateStudent)
                .AddEndpointFilter<StudentValidationFilters>();
            post.MapDelete("/{id}", DeleteStudent);
        }

        private async Task<IResult> GetStudentById(IMediator mediator, int StudentId)
        {
            var getStudent = new GetStudentById { StudentId = StudentId };
            var student = await mediator.Send(getStudent);
            return TypedResults.Ok(student);
        }

        private async Task<IResult> CreateStudent(IMediator mediator, Student student)
        {
            var createStudent = new CreateStudent { Name = student.Name, Class = student.Class };
            var createdStudent = await mediator.Send(createStudent);
            return Results.CreatedAtRoute("GetStudentById", new { createdStudent.Id }, createdStudent);
        }

        private async Task<IResult> GetAllStudents(IMediator mediator)
        {
            var getCommand = new GetAllStudents();
            var students = await mediator.Send(getCommand);
            return TypedResults.Ok(students);
        }

        private async Task<IResult> UpdateStudent(IMediator mediator, Student student, int StudentId)
        {
            var updateStudent = new UpdateStudent {StudentId = StudentId, Name = student.Name, Class = student.Class};
            var updetedStudent = await mediator.Send(updateStudent);
            return TypedResults.Ok(updetedStudent);
        }

        private async Task<IResult> DeleteStudent(IMediator mediator, int StudentId)
        {
            var deleteStudent = new DeleteStudent { StudentId = StudentId };
            await mediator.Send(deleteStudent);
            return TypedResults.NoContent();
        }
    }
}
