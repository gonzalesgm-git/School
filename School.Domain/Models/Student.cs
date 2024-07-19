﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Domain.Models;

public class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(100")]
    public string FirstName { get; set; } = string.Empty;
    [Column(TypeName = "nvarchar(100")]
    public string LastName { get; set; } = string.Empty;
    [Column(TypeName = "datetime")]
    public DateTime BirthDate { get; set; }
    [Column(TypeName = "nvarchar(20)")]
    public string PhoneNumber { get; set; } = string.Empty;
}
