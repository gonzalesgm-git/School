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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>()
                .HasOne(a => a.Student)
                .WithMany(x => x.Applications)
                .HasForeignKey(a => a.StudentId);
                
                
        }
    }
}
