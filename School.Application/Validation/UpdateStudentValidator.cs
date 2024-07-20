using FluentValidation;
using School.Domain.Models;
using School.Infrastructure.Repositories;

namespace School.Application.Validation
{
    public  class UpdateStudentValidator: AbstractValidator<Student>
    {
        public UpdateStudentValidator(IStudentRepository _studentRepository)
        {
            RuleFor(s => s.FirstName)
               .NotEmpty().WithMessage("FirstName must not be empty.")
               .Must(s => s.Length >= 2 && s.Length <= 30).WithMessage("FirstName must be between 2-30 characters long");

            RuleFor(s => s.LastName)
                .NotEmpty().WithMessage("LastName must not be empty.")
                .Must(s => s.Length >= 2 && s.Length <= 30).WithMessage("LastName must be between 2-30 characters long");

            RuleFor(s => s.Email)
                .EmailAddress().WithMessage("A valid email is required");

           
            RuleFor(s => s.Id)
                .MustAsync(async (id, studentRepository) => {
                    var students = await _studentRepository.GetAllAsync();
                    return  students.Any(x => x.Id == id);
                }).WithMessage($"Student not existing");

        }
    }
}
