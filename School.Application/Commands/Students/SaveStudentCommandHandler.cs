using MediatR;
using School.Application.Validation;
using School.Domain.Models;
using School.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace School.Application.Commands.Students
{
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
                return Result.Fail(string.Join(",", validatorResult.Errors.Select(x => x.ErrorMessage)));
            }

            await _repository.SaveAsync(command.student);
            return Result.OK();
        }
    }
}
