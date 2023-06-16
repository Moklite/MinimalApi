using Domain.Models;
using MediatR;

namespace Application.Students.Commands
{
    public class UpdateStudent : IRequest<Student>
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
    }
}
