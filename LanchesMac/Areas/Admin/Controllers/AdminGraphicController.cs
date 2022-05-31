using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Areas.Admin.Controllers
{
    public class AdminGraphicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
