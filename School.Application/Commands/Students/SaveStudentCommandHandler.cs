using MediatR;
using School.Application.Validation;
using School.Domain.Models;
using School.Infrastructure.Repositories;

namespace School.Application.Commands.Students
{
    public record SaveStudentCommand(Student student) : IRequest<Result>;
    public class SaveStudentCommandHandler : IRequestHandler<SaveStudentCommand, Result>
    {
        private IStudentRepository _repository;
        public SaveStudentCommandHandler(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(SaveStudentCommand command, CancellationToken cancellationToken)
        {
            var validator = new SaveStudentValidator();
            var validatorResult = await validator.ValidateAsync(command.student);
            if (!validatorResult.IsValid)
            {
                return Result.Fail(validatorResult.Errors.Select(x => new Error(x.ErrorMessage)).ToArray());
            }

            await _repository.SaveAsync(command.student);
            return Result.OK();
        }
    }
}
