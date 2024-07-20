using MediatR;
using School.Domain.Models;
using School.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Commands.Courses
{
    public record UpdateCourseCommand(Course course): IRequest<Result>;
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, Result>
    {
        private ICourseRepostory _courseRepository;
        public UpdateCourseCommandHandler(ICourseRepostory courseRepostory)
        {
            _courseRepository = courseRepostory;
        }

        public async Task<Result> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var res = await _courseRepository.UpdateItemAsync(request.course);
            return Result.OK();
        }
    }
}
