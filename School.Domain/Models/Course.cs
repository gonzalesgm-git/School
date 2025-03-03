﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Domain.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName ="nvarchar(50)")]
        public string Code { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(100)")]
        public string Title { get; set; } = string.Empty;
        [Column(TypeName = "int")]
        public int Credits { get; set; }
    }
}
