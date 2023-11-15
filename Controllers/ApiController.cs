using Microsoft.AspNetCore.Mvc;
using MSIT153.ViewModels;

namespace MSIT153.Controllers
{
    public class ApiController : Controller
    {
        //public IActionResult Index(string name,int age)
        private readonly IWebHostEnvironment _host;
        public ApiController(IWebHostEnvironment host)
        {
            _host = host;
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
    }
}
