using Microsoft.AspNetCore.Mvc;
using WebAppDemo.Models;
namespace WebAppDemo.Controllers
{
    public class BookController : Controller
    {
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {

            return View();
        }
    }
}
