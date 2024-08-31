using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFdemo.Models
{
    [Table("book")]
    public class Book
    {
        [Key]
        [Display(Name ="Book Id")]
        public int Bid { get; set; }

        [Required]
        [Display(Name ="Book Name")]
        public string? Bname { get; set; }

        [Required]
        [Display(Name ="Book Author")]
        public string? Author { get; set; }

        [Required]
        [Display(Name ="Book Price")]
        public decimal Bprice { get; set; }

    }
}
