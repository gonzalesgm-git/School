using MediatR;
using School.Domain.Models;
using School.Infrastructure.Repositories;

namespace School.Application.Queries.Courses
{
    public record CourseListQuery() : IRequest<IEnumerable<Course>>;
    public class CourseListQueryHandler : IRequestHandler<CourseListQuery, IEnumerable<Course>>
    {
        private ICourseRepostory _courseRepository;
        public CourseListQueryHandler(ICourseRepostory courseRepostory)
        {
            _courseRepository = courseRepostory;
        }

        public async Task<IEnumerable<Course>> Handle(CourseListQuery request, CancellationToken cancellationToken)
        {
            return await _courseRepository.GetAllAsync();
        }
    }
}
