using MediatR;
using School.Application.Validation;
using School.Domain.Models;
using School.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Commands.Applications
{
    public record SaveApplicationCommand(Domain.Models.Application application) : IRequest<Result>;
    public class SaveApplicationCommandHandler : IRequestHandler<SaveApplicationCommand, Result>
    {
        private IApplicationRepository _applicationRepository;
        private IStudentRepository _studentRepository;
        private ICourseRepostory _courseRepository;
        public SaveApplicationCommandHandler(IApplicationRepository application, 
            IStudentRepository studentRepository, 
            ICourseRepostory courseRepository)
        {
            _applicationRepository = application;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;   
        }

        public async Task<Result> Handle(SaveApplicationCommand request, CancellationToken cancellationToken)
        {
            var validator = new SaveApplicationValidator(_studentRepository, _courseRepository, cancellationToken);
            var validatorResult = await validator.ValidateAsync(request.application);
            if (!validatorResult.IsValid)
            {
                return Result.Fail(validatorResult.Errors.Select(x => new Error(x.ErrorMessage)).ToArray());
            }
            var res = await _applicationRepository.SaveAsync(request.application);
            return Result.OK();
        }
    }
}
