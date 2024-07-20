using MediatR;
using School.Domain.Models;
using School.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Commands.Students
{
    internal class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, Result>
    {
        private IStudentRepository _studentRepository;
        public DeleteStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Result> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var success = await _studentRepository.DeleteItemAsync(request.id);
            return success ? Result.OK() : Result.Fail("Saving failed");
        }
    }
}
