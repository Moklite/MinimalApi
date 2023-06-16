using Domain.Models;
using MediatR;

namespace Application.Students.Commands
{
    public class CreateStudent : IRequest<Student>
    {
        public string Name { get; set; }
        public string Class { get; set; }
    }
}
