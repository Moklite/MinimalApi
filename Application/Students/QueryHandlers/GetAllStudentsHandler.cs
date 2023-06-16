using Application.Abstractions;
using Application.Students.Queries;
using Domain.Models;
using MediatR;

namespace Application.Students.QueryHandlers
{
    public class GetAllStudentsHandler : IRequestHandler<GetAllStudents, ICollection<Student>>
    {
        private readonly IStudentRepository _studentRepository;
        public GetAllStudentsHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        public async Task<ICollection<Student>> Handle(GetAllStudents request, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetAllStudents();
        }
    }
}
