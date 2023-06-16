using Application.Abstractions;
using Application.Students.Commands;
using MediatR;

namespace Application.Students.CommandHandlers
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudent>
    {
        private readonly IStudentRepository _studentRepository;
        public DeleteStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task Handle(DeleteStudent request, CancellationToken cancellationToken)
        {
            await _studentRepository.DeleteStudent(request.StudentId);
        }
    }
}
