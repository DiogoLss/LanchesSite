using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
