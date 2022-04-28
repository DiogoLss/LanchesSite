using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModels;
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
            //var snacks = _snackRepository.Snacks;
            //return View(snacks);
            var snackListViewModel = new SnackListViewModel();
            snackListViewModel.Snacks = _snackRepository.Snacks;
            snackListViewModel.CurrentCategory = "Current Category.";
            return View(snackListViewModel);
        }
    }
}
