using LanchesMac.Areas.Admin.services;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminGraphicController : Controller
    {
        private readonly SalesGraphicService _graphic;

        public AdminGraphicController(SalesGraphicService graphic)
        {
            _graphic = graphic;
        }

        public JsonResult SnacksSales(int days)
        {
            var snacksSalesTotal = _graphic.GetSnackSales(days);
            return Json(snacksSalesTotal);
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MonthlySales()
        {
            return View();
        }
        [HttpGet]
        public IActionResult WeeklySales()
        {
            return View();
        }
    }
}
