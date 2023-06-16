using Domain.Models;
using MediatR;

namespace Application.Students.Queries
{
    public class GetAllStudents : IRequest<ICollection<Student>>
    {
    }
}
