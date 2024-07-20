using MediatR;
using School.Domain.Models;
using School.Infrastructure.Repositories;

namespace School.Application.Queries.Students
{
    public record StudentQuery(int id) : IRequest<Student>;
    internal class StudentQueryHandler : IRequestHandler<StudentQuery, Student>
    {
        private IStudentRepository _studentRepository;
        public StudentQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> Handle(StudentQuery request, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetAsync(request.id);
        }
    }
}
