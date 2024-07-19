using FluentValidation;
using School.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Validation
{
    public class SaveStudentValidator: AbstractValidator<Student>
    {
        public SaveStudentValidator() 
        {
            RuleFor(s => s.FirstName).NotEmpty().WithMessage("FirstName must not be empty.");
            RuleFor(s => s.LastName).NotEmpty().WithMessage("LastName must not be empty.");
            RuleFor(s => s.BirthDate).NotEmpty().WithMessage("BirthDate must not be empty.");
            RuleFor(s => s.PhoneNumber).NotEmpty().WithMessage("PhoneNumber must not be empty.");
        }
    }
}
