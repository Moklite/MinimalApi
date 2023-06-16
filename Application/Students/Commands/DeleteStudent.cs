using MediatR;

namespace Application.Students.Commands
{
    public class DeleteStudent : IRequest
    {
        public int StudentId { get; set; }
    }
}
