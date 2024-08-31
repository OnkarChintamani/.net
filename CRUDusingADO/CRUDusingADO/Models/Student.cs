using System.ComponentModel.DataAnnotations;

namespace CRUDusingADO.Models
{
    public class Student
    {
        [Key]
        public int RollNo { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public double Marks {  get; set; }

    }
}
