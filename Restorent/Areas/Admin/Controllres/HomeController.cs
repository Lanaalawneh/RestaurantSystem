using Microsoft.AspNetCore.Mvc;

namespace Restorent.Areas.Admin.Controllres
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
