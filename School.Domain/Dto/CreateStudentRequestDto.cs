using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Dto
{
    public class CreateStudentRequestDto
    {
        public string FirstName { get; set; } = string.Empty;
        
        public string LastName { get; set; } = string.Empty;
        
        public string Email { get; set; } = string.Empty;
        
        public DateTime BirthDate { get; set; }
        
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
