using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFdemo.Models
{
    [Table ("student")]
    public class Student
    {
        [Key]
        public int RollNo { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Marks {  get; set; }
    }
}
