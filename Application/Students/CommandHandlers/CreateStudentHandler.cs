using Application.Abstractions;
using Application.Students.Commands;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.CommandHandlers
{
    public class CreateStudentHandler : IRequestHandler<CreateStudent, Student>
    {
        private readonly IStudentRepository _studentRepository;
        public CreateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> Handle(CreateStudent request, CancellationToken cancellationToken)
        {
            var student = new Student
            {
                Name = request.Name,
                Class = request.Class
            };
           return await _studentRepository.CreateStudent(student);
        }
    }
}
