using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.UI.Site.Areas.Admin
{
    [Area("Admin")]
    [Authorize]
    public abstract class BaseController : Controller
    { 
        
    }
}
