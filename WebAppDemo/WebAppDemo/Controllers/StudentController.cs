using Microsoft.AspNetCore.Mvc;

namespace WebAppDemo.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult AddStudent()
        {
            return View();
        }
    }
}
