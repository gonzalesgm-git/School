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

namespace School.Application.Commands
{
    internal class SaveStudentCommandHandler: IRequestHandler<SaveStudentCommand, Result<Student>>
    {
        private IStudentRepository _repository;
        public SaveStudentCommandHandler(IStudentRepository repository) 
        {
            _repository = repository;
        }
       
        public async Task<Result<Student>> Handle(SaveStudentCommand command, CancellationToken cancellationToken)
        {
            var validator = new SaveStudentValidator();
            var validatorResult = await validator.ValidateAsync(command.student);
            if (!validatorResult.IsValid)
            {
                return  Result<Student>.IsFail(validatorResult.Errors.Select(e => e.ErrorMessage).ToArray());
            }

            await _repository.SaveAsync(command.student);
            return Result<Student>.Ok(command.student);
        }
    }
}
