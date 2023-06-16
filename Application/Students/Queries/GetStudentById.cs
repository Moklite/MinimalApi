using Domain.Models;
using MediatR;

namespace Application.Students.Queries
{
    public class GetStudentById : IRequest<Student>
    {
        public int StudentId { get; set; }
    }
}
