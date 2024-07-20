using MediatR;
using School.Domain.Models;
using School.Infrastructure.Repositories;

namespace School.Application.Queries.Students
{
    public record StudentListQuery : IRequest<IEnumerable<Student>>;
    public class StudentListQueryHandler : IRequestHandler<StudentListQuery, IEnumerable<Student>>
    {

        private IStudentRepository _repository;
        public StudentListQueryHandler(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Student>> Handle(StudentListQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
