using MediatR;
using School.Application.Validation;
using School.Domain.Models;
using School.Infrastructure.Repositories;

namespace School.Application.Commands.Students
{
    public record UpdateStudentCommand(Student student) : IRequest<Result>;
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Result>
    {
        IStudentRepository _studentRepository;
        public UpdateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Result> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateStudentValidator(_studentRepository);
            var validatorResult = await validator.ValidateAsync(request.student);
            if (!validatorResult.IsValid)
            {
                return Result.Fail(validatorResult.Errors.Select(x => new Error(x.ErrorMessage)).ToArray());
            }

            var res = await _studentRepository.UpdateItemAsync(request.student);
            return Result.OK();
        }
    }
}
