using MediatR;
using School.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Commands.Students
{
    public record class DeleteStudentCommand(int id) : IRequest<Result>;
}
