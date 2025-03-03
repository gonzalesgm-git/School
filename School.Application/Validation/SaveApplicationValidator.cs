﻿using FluentValidation;
using School.Infrastructure.Repositories;

namespace School.Application.Validation
{
    public class SaveApplicationValidator : AbstractValidator<Domain.Models.Application>
    {
        public SaveApplicationValidator(IStudentRepository _studentRepository, ICourseRepostory _courseRepository, CancellationToken token)
        {
            RuleFor(a => a.StudentId)
                .MustAsync(async (id, token) => {
                    return  await _studentRepository.Exists(id);
                }).WithMessage($"Student not existing");
            RuleFor(a => a.CourseId)
                .MustAsync(async (id, studentRepository) => {
                    return  await _courseRepository.Exists(id);
                }).WithMessage($"Course not existing");
        }
    }
}
