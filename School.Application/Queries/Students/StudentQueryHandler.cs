using MediatR;
using School.Domain.Models;
using School.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Queries.Students
{
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
