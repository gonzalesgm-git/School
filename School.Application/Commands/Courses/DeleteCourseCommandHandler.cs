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
    public record DeleteCourseCommand(int id): IRequest<Result>;
    internal class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, Result>
    {
        private ICourseRepostory _courseRepository;
        public DeleteCourseCommandHandler(ICourseRepostory courseRepostory)
        {
            _courseRepository = courseRepostory;
        }

        public async Task<Result> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var res = await _courseRepository.DeleteItemAsync(request.id);
            return Result.OK();
        }
    }
}
