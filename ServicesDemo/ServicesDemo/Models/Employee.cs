﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicesDemo.Models
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public decimal Salary { get; set; }

        [Required]
        public int IsActive { get; set; }
    }
}
