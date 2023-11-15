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

        public IActionResult Index()
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
        public IActionResult Homework1()
        {
            return View();
        }
        public IActionResult Homework2()
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