﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Models
{
    public class Application
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Column(TypeName ="int")]
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student? Student { get; set; }


        [Column(TypeName = "int")]
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course? Course { get; set; }


        [Column(TypeName = "datetime")]
        public DateTime ApplicationDate { get; set; }
    }
}
