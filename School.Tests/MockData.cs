﻿using School.Domain.Models;

namespace School.Tests
{
    public class MockData
    {
        public List<Student> GetStudents()
        {
            Random rnd = new Random();
            var id = rnd.Next(1, 100);
            IEnumerable<Student> students = Enumerable.Repeat(
                new Student
                {
                    Id = id,
                    BirthDate = DateTime.Now,
                    FirstName = $"FirstName-{id}",
                    LastName = $"LastName-{id}",
                    PhoneNumber = $"PhoneNumber-{id}"
                }, 100);

            
            return students.ToList();
        }

    


    }
}
