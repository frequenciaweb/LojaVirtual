using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.UI.Site.Areas.Admin.Controllers
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
