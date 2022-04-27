using LanchesMac.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class SnackController : Controller
    {
        private readonly ISnackRepository _snackRepository;
        public SnackController(ISnackRepository snackRepository)
        {
            _snackRepository = snackRepository;
        }

        public IActionResult List()
        {
            ViewData["Title"] = "All Snacks";
            ViewData["Date"] = DateTime.Now;

            var snacks = _snackRepository.Snacks;

            var totalLanches = snacks.Count();

            ViewBag.Total = "Total of snacks";
            ViewBag.TotalSnacks = totalLanches;

            return View(snacks);
        }
    }
}
