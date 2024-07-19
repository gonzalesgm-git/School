using MediatR;
using School.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Queries
{
   public record StudentQuery(int id): IRequest<Student>;
        
}
