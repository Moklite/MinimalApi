using Application.Abstractions;
using Application.Students.Queries;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.QueryHandlers
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentById, Student>
    {
        private readonly IStudentRepository _studentRepository;
        public GetStudentByIdHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> Handle(GetStudentById request, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetStudentById(request.StudentId);
        }
    }
}
