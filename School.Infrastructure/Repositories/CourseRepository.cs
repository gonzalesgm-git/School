using Microsoft.EntityFrameworkCore;
using School.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrastructure.Repositories
{
    public interface ICourseRepostory : IRepository<Course>
    {
        Task<bool> Exists(int id);
    }
    public class CourseRepository : ICourseRepostory
    {
        private SchoolDbContext _context;
        public CourseRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var course = await GetAsync(id);
             _context.Courses.Remove(course);
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Courses.AnyAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses.AsNoTracking().ToListAsync();
        }

        public async Task<Course> GetAsync(int id)
        {
            return await _context.Courses.Where(x => x.Id == id).FirstAsync();
        }

        public async Task<bool> SaveAsync(Course item)
        {
            _context.Courses.Add(item);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateItemAsync(Course item)
        {
            _context.Courses.Update(item);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
