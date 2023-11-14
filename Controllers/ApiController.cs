using Microsoft.AspNetCore.Mvc;

namespace MSIT153.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index(string name,int age)
        {
            return Content($"Hello {name}!! I'm {age} years old.");
        }
    }
}
