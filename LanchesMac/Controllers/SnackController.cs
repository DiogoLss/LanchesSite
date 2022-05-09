using LanchesMac.Models;
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

        public IActionResult List(string category)
        {
            IEnumerable<Snack> snacks;
            string currentCategory = string.Empty;
            if (string.IsNullOrEmpty(category))
            {
                snacks = _snackRepository.Snacks.OrderBy(l => l.SnackId);
                currentCategory = "All snacks";
            }
            else
            {
                snacks = _snackRepository.Snacks
                    .Where(s => s.Category.CategoryName.Equals(category)).OrderBy(c => c.Name);
                currentCategory = category;
            }
            var snackListViewModel = new SnackListViewModel
            {
                Snacks = snacks,
                CurrentCategory = currentCategory
            };

            return View(snackListViewModel);
        }
        public IActionResult Details(int snackId)
        {
            var snack = _snackRepository.Snacks.FirstOrDefault(s => s.SnackId == snackId);
            return View(snack);
        }
        public IActionResult Search(string searchString)
        {
            IEnumerable<Snack> snacks;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                snacks = _snackRepository.Snacks.OrderBy(s => s.SnackId);
                currentCategory = "All snacks";
            }
            else
            {
                snacks = _snackRepository.Snacks
                    .Where(s => s.Name.ToLower().Contains(searchString.ToLower()) 
                    || s.ShortDescription.ToLower().Contains(searchString.ToLower()));
                if (snacks.Any()) { currentCategory = "All results found by " + searchString; }
                else { currentCategory = "No snacks were found by " + searchString; }
            }
            return View("~/Views/Snack/List.cshtml", new SnackListViewModel
            {
                Snacks=snacks,
                CurrentCategory=currentCategory
            });
        }
    }
}
