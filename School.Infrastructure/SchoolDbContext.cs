using Microsoft.EntityFrameworkCore;
using School.Domain.Models;

namespace School.Infrastructure
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students{ get; set; }
        public DbSet<Course> Courses{ get; set; }
        public DbSet<Application> Applications{ get; set; }
    }
}
