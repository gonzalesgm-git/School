using MediatR;
using School.Domain.Models;
using School.Infrastructure.Repositories;

namespace School.Application.Queries.Courses
{
    public record CourseQuery(int id) : IRequest<Course>;
    public class CourseQueryHandler : IRequestHandler<CourseQuery, Course>
    {
        private ICourseRepostory _courseRepository;
        public CourseQueryHandler(ICourseRepostory courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<Course> Handle(CourseQuery request, CancellationToken cancellationToken)
        {
            var res = await _courseRepository.GetAsync(request.id);
            return res;
        }
    }   
}
