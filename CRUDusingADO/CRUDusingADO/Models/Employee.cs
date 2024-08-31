using System.ComponentModel.DataAnnotations;

namespace CRUDusingADO.Models
{
    public class Employee
    {
        [Key]//this is PK in the table
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }//? to allow null value from DB
        [Required]
        public string? City {  get; set; }
        [Required]
        public double Salary {  get; set; }
    }
}
