using LanchesMac.Areas.Admin.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminSalesReportController : Controller
    {
        private readonly SalesReportService _salesReport;
        public AdminSalesReportController(SalesReportService salesReport)
        {
            _salesReport = salesReport;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SimpleSalesReport(DateTime? minDate,DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _salesReport.FindByDateAsync(minDate,maxDate);
            return View(result);
        }
    }
}
