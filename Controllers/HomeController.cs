using Microsoft.AspNetCore.Mvc;
using MSIT153.Models;
using System.Diagnostics;

namespace MSIT153.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly dbDemoContext _context;

        public HomeController(ILogger<HomeController> logger, dbDemoContext Context)
        {
            _logger = logger;
            _context = Context;
        }

        public ActionResult History()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Partial2()
        {
            ViewBag.kk = "來自partial2 Action";
            return PartialView();
        }
        
        public IActionResult Partial1()
        {
            return PartialView();
        }

        public IActionResult jQuery()
        {
            return View();
        }

        public IActionResult test()
        {
            var n = _context.Members;
            return View(n);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult First()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Address()
        {
            return View();
        }
        public IActionResult Fetch()
        {
            return View();
        }
        public IActionResult Homework1()
        {
            return View();
        }
        public IActionResult Homework2()
        {
            return View();
        }
        public IActionResult Homework3()
        {
            return View();
        }
        public IActionResult Homework31()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}