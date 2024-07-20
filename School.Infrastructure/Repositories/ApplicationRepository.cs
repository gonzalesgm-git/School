using Microsoft.EntityFrameworkCore;
using School.Domain.Dto.Response;
using School.Domain.Models;

namespace School.Infrastructure.Repositories
{
    public interface IApplicationRepository : IRepository<Application>
    {
        Task<IEnumerable<ApplicationInfoResponse>> GetApplicationInfo();
    }
    internal class ApplicationRepository : IApplicationRepository
    {
        private SchoolDbContext _context;
        public ApplicationRepository(SchoolDbContext context)
        {
            _context = context; 
        }

        public Task<bool> DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public  async Task<IEnumerable<Application>> GetAllAsync()
        {
            return await _context.Applications.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<ApplicationInfoResponse>> GetApplicationInfo()
        {
            var res = await (from app in _context.Applications
                        join stud in _context.Students on app.StudentId equals stud.Id
                        join c in _context.Courses on app.CourseId equals c.Id
                        select new ApplicationInfoResponse
                        {
                            ApplicationDate = app.ApplicationDate,
                            Course = c.Title,
                            StudentName = $"{stud.FirstName} {stud.LastName}"
                        }).ToListAsync();

            return res;
        }

        public Task<Application> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAsync(Application item)
        {
            var res = _context.Applications.Add(item);
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<bool> UpdateItemAsync(Application item)
        {
            throw new NotImplementedException();
        }
    }
}
