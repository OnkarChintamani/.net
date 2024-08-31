
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppDemo.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Page2()
        {
            List<string> cities = new List<string>
            {
                "pune","mumbai","delhi","nagpur"
            };
            ViewData["cities"]=new SelectList(cities);
           
            return View();
        }
        [HttpPost]
        public IActionResult Page2(IFormCollection form)
        {
            ViewBag.UserName = form["first"];
            ViewBag.Email = form["email"];
            ViewBag.Gender = form["gender"];
            ViewBag.Cities = form["cities"];
            return View("Page3");
        }
    }
}
