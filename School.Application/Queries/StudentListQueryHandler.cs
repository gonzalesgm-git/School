using MediatR;
using School.Domain.Models;
using School.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Queries
{
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
