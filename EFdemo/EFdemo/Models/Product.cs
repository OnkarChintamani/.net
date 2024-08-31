using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFdemo.Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }
        [Required]
        [Display(Name ="Product Name")]
        public string? ProductName { get; set; }
        [Required]
        [Display(Name = "Product Price")]
        public int ProductPrice { get; set; }
    }
}
