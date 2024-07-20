using MediatR;
using School.Domain.Models;
using School.Infrastructure.Repositories;

namespace School.Application.Commands.Students
{
    public record class DeleteStudentCommand(int id) : IRequest<Result>;
    internal class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, Result>
    {
        private IStudentRepository _studentRepository;
        public DeleteStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Result> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var success = await _studentRepository.DeleteItemAsync(request.id);
            return success ? Result.OK() : Result.Fail("Saving failed");
        }
    }
}
