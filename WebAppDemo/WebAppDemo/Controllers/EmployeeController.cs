using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppDemo.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult EmployeeDetails()
        {
            List<string> cities = new List<string>
            {
                "pune","mumbai","delhi","nagpur"
            };
            ViewData["cities"] = new SelectList(cities);

            List<string> dept = new List<string>
            {
                "MANAGER","HR","Account","TECNICAL"
            };
            ViewData["dept"] = new SelectList(dept);

            return View();
        }
        [HttpPost]
        public IActionResult EmployeeDetails(IFormCollection form)
        {
            ViewBag.Name = form["name"];
            ViewBag.Email = form["email"];
            ViewBag.Gender = form["gender"];
            ViewBag.Cities = form["cities"];
            ViewBag.Dept = form["dept"];
            ViewBag.QualiFication = form["qualification"];

            return View("PrintDetails");
        }
    }
}
