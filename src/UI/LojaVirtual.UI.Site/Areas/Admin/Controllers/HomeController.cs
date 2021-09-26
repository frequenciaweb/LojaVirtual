using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.UI.Site.Areas.Admin.Controllers
{    
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
