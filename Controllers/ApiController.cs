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
            //Thread.Sleep(5000);
            if (string.IsNullOrEmpty(user.name))
            {
                user.name = "guest";
            }
            //return Content("<h2>Ajax 你好 !!</h2>","text/html", System.Text.Encoding.UTF8);
            return Content($"Hello {user.name}!! I'm {user.age} years old.");
        }

        public IActionResult GetImageByte(int id = 1)
        {
            Members? member = _context.Members.Find(id);
            byte[]? img = member?.FileData;
            if (img != null)
            {
                return File(img, "image/jpeg");
            }
            return NotFound();
        }

        public IActionResult Cities()
        {
            var cities=_context.Address.Select(_ => _.City).Distinct();
            return Json(cities);
        }

        public IActionResult districts(string city)
        {
            var districts = _context.Address.Where(_ => _.City == city).Select(_=>_.SiteId).Distinct();
            return Json(districts);
        }

        public IActionResult road(string district)
        {
            var road = _context.Address.Where(_ => _.SiteId == district).Select(_=>_.Road).Distinct();
            return Json(road);
        }

        public IActionResult register(Members members, IFormFile formFile)
        {
            //實際路徑
            //C:\Users\User\Documents\workspace\MSIT153Site\wwwroot\uploads\abc.jpg
            //專案跟目錄的路徑
            //string strPath = _host.ContentRootPath; //C:\Users\User\Documents\workspace\MSIT153Site
            //wwwroot的實際路徑
            //string strPath = _host.WebRootPath; //C:\Users\User\Documents\workspace\MSIT153Site\wwwroot
            string strPath = Path.Combine(_host.WebRootPath, "uploads", formFile.FileName);

            using (var fileStream = new FileStream(strPath, FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }
            members.FileName = formFile.FileName;

            //將上傳的圖轉為二進位
            byte[]? imgByte = null;
            using (var memoryStream = new MemoryStream())
            {
                formFile.CopyTo(memoryStream);
                imgByte = memoryStream.ToArray();
            }
            members.FileData = imgByte;

            //資料寫進資料庫
            _context.Members.Add(members);
            _context.SaveChanges();

            return Content("資料新增成功");

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
