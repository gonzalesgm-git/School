using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using School.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<SchoolDbContext>(options => {
                options.UseInMemoryDatabase(databaseName: "Test");
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICourseRepostory, CourseRepository>();
            return services;
        }
    }
}
