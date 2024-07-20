using FluentValidation;
using School.Domain.Models;

namespace School.Application.Validation
{
    public class SaveStudentValidator: AbstractValidator<Student>
    {
        public SaveStudentValidator() 
        {
            RuleFor(s => s.FirstName)
                .NotEmpty().WithMessage("FirstName must not be empty.")
                .Must(s =>  s.Length >= 2 && s.Length <= 30).WithMessage("FirstName must be between 2-30 characters long");

            RuleFor(s => s.LastName)
                .NotEmpty().WithMessage("LastName must not be empty.")
                .Must(s => s.Length >= 2 && s.Length <= 30).WithMessage("LastName must be between 2-30 characters long");

            RuleFor(s => s.Email)
                .EmailAddress().WithMessage("A valid email is required");

            RuleFor(s => s.BirthDate).NotEmpty().WithMessage("BirthDate must not be empty.");
         
        }
    }
}
