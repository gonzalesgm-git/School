using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using School.Domain.Models;

namespace School.Application.Commands;

public record SaveStudentCommand(Student student): IRequest<Result<Student>>;

