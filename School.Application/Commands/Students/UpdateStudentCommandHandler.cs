using MediatR;
using School.Application.Validation;
using School.Domain.Models;
using School.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Commands.Students
{
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
                return Result.Fail(string.Join(", ", validatorResult.Errors.Select(x => x.ErrorMessage)));
            }

            var res = await _studentRepository.UpdateItemAsync(request.student);
            return Result.OK();
        }
    }
}
