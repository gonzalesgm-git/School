﻿using Microsoft.EntityFrameworkCore;
using School.Domain.Models;

namespace School.Infrastructure.Repositories
{
    public interface IStudentRepository: IRepository<Student>
    {
        Task<bool> Exists(int id);
    }
    internal class StudentRepository : IStudentRepository
    {
        private SchoolDbContext _context;
        public StudentRepository(SchoolDbContext context)
        {
            _context = context; 
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var itemToDelete = await GetAsync(id);
            _context.Students.Remove(itemToDelete);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Student> GetAsync(int id)
        {
            return await _context.Students.Where(x => x.Id == id).FirstAsync();
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.AsNoTracking().ToListAsync();
        }

        public async Task<bool> SaveAsync(Student item)
        {
            _context.Students.Add(item);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateItemAsync(Student item)
        {
            _context.Students.Update(item);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Exists(int id)
        {
           return await _context.Students.AnyAsync(x => x.Id == id);
        }
    }
}
