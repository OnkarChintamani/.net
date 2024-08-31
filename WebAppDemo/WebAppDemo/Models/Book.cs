using System.ComponentModel.DataAnnotations;
namespace WebAppDemo.Models
{
    public class Book
    {
        [Required (ErrorMessage ="Book Id Is Required")]
        public int BookId {  get; set; }

        [Required(ErrorMessage = "Book Title Is Required")]
        [Display (Name ="Book Title ")]
        public string BookTitle { get; set; }

        [Required(ErrorMessage = "Book Price Is Required")]
        [Display(Name = "Book Price ")]
        public double BookPrice {  get; set; }
    }
}
