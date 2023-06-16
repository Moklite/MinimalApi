using Application.Abstractions;
using Application.Students.Commands;
using Domain.Models;
using MediatR;

namespace Application.Students.CommandHandlers
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudent, Student>
    {
        private readonly IStudentRepository _studentRepository;
        public UpdateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> Handle(UpdateStudent request, CancellationToken cancellationToken)
        {
            var student = new Student
            {
                Name = request.Name,
                Class = request.Class
            };
            return await _studentRepository.UpdateStudent(student, request.StudentId);
        }
    }
}
