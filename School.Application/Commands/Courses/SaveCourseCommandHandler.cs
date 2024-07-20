﻿using MediatR;
using School.Domain.Models;
using School.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Commands.Courses
{
    public record SaveCourseCommand(Course course) : IRequest<Result>;
    public class SaveCourseCommandHandler : IRequestHandler<SaveCourseCommand, Result>
    {
        ICourseRepostory _courseRepository;
        public SaveCourseCommandHandler(ICourseRepostory courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<Result> Handle(SaveCourseCommand request, CancellationToken cancellationToken)
        {
            var res = await _courseRepository.SaveAsync(request.course);
            return Result.OK();
        }
    }
}
