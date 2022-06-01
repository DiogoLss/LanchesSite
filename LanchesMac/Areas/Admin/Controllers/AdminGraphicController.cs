using LanchesMac.Areas.Admin.services;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Areas.Admin.Controllers
{
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
        public IActionResult Index(int days)
        {
            return View();
        }
        [HttpGet]
        public IActionResult MonthlySales(int days)
        {
            return View();
        }
        [HttpGet]
        public IActionResult WeeklySales(int days)
        {
            return View();
        }
    }
}
