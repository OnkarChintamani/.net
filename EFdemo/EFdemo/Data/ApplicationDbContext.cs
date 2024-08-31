using EFdemo.Models;
using Microsoft.EntityFrameworkCore;
namespace EFdemo.Data
{
    //ApplicationDbContext --- child class, DBContext -parent class of EF
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
            
        }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Book> Books { get; set; }
    }
}
