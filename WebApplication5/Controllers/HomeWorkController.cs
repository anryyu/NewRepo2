using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class HomeWorkController : Controller
    {
        private readonly MyDBContext _context;
        public HomeWorkController(MyDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
