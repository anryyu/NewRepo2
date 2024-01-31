using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;
using System.Text;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class ApiController : Controller
    {
        private readonly MyDBContext _context;
        public ApiController(MyDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            Thread.Sleep(3000);
            return Content("Hello", "text/plain", Encoding.UTF8);
        }
        public IActionResult Register(string name, int age = 28)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = "guest";
            }
            return Content($"Hello {name}, {age}歲了", "text/plain", Encoding.UTF8);
        }
        private bool MemberCheckUserName(string name)
        {
            var Member = _context.Members.FirstOrDefault(m => m.Name == name);
            return Member != null;
        }
        public IActionResult CheckAccountAction(string name)
        {
            bool IsExists = MemberCheckUserName(name);
            return IsExists ? Content("帳號已存在!", "text/plain", Encoding.UTF8) : Content("帳號可使用!", "text/plain", Encoding.UTF8);
        }
        public IActionResult PushData(string name,string email, int age = 28)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = "guest";
            }
            return Content($"Hello {name}, {age}歲了,電子郵件是{email}.", "text/plain", Encoding.UTF8);
        }
        public IActionResult Cities()
        {
          
            var cities = _context.Addresses.Select(a => a.City).Distinct();
            return Json(cities);
        }
        public IActionResult District(string city)
        {
            var districts = _context.Addresses.Where(a => a.City == city).Select(a => a.SiteId).Distinct();
            return Json(districts);
        }
        public IActionResult Road(string site)
        {
            var roads = _context.Addresses.Where(a => a.SiteId == site).Select(a => a.Road).Distinct();
            return Json(roads);
        }
        public IActionResult Avatar(int id = 1)
        {
            Member? member = _context.Members.Find(id);
            if (member != null)
            {
                byte[] img = member.FileData;
                if (img != null) {
                    {
                        return File(img, "image/jpeg");
                    }
                }
            }
            return NotFound();
        }
    }
}
