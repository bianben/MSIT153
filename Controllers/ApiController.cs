using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MSIT153.Models;
using MSIT153.ViewModels;

namespace MSIT153.Controllers
{
    public class ApiController : Controller
    {
        //public IActionResult Index(string name,int age)
        private readonly IWebHostEnvironment _host;
        private readonly dbDemoContext _context;

        public ApiController(IWebHostEnvironment host, dbDemoContext Context)
        {
            _host = host;
            _context = Context;
        }
        public IActionResult Index(UserViewModel user)
        {
            Thread.Sleep(5000);
            if (string.IsNullOrEmpty(user.name))
            {
                user.name = "guest";
            }
            //return Content("<h2>Ajax 你好 !!</h2>","text/html", System.Text.Encoding.UTF8);
            return Content($"Hello {user.name}!! I'm {user.age} years old.");
        }
        public IActionResult register(MemberViewModel member, IFormFile formFile)
        {
            //實際路徑
            //C:\Users\User\Documents\workspace\MSIT153Site\wwwroot\uploads\abc.jpg
            //string strPath = _host.ContentRootPath; //C:\Users\User\Documents\workspace\MSIT153Site
            //tring strPath = _host.WebRootPath; //C:\Users\User\Documents\workspace\MSIT153Site\wwwroot
            string strPath = Path.Combine(_host.WebRootPath, "uploads", formFile.FileName);

            using (var fileStream = new FileStream(strPath, FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }
            return Content(strPath);

            //return Content("<h2>Ajax 你好 !!</h2>","text/html", System.Text.Encoding.UTF8);
            //return Content($"Hello {member.name}，{member.email},  You are {member.age} years old.");
        }
        public IActionResult Homework2api(string Name)
        {
            var q = _context.Members.Select(m => m.Name);

            if (string.IsNullOrEmpty(Name))
                return Content("請輸入暱稱");
            
            if(q.Contains(Name))
                return Content("此暱稱已有人使用");

            return Content("此暱稱可以使用");

        }
    }
}
