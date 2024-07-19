using MediatR;
using School.Domain.Models;
using School.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Commands
{
    internal class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, Result<Student>>
    {
        private IStudentRepository _studentRepository;
        public DeleteStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Result<Student>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var success =  await _studentRepository.DeleteItemAsync(request.id);
            return success ? Result<Student>.IsSuccess() : Result<Student>.IsFail();
        }
    }
}
