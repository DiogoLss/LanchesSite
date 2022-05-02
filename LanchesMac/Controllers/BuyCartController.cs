using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class BuyCartController : Controller
    {
        private readonly ISnackRepository _snackRepository;
        private readonly BuyCart _buyCart;

        public BuyCartController(ISnackRepository snackRepository, BuyCart buyCart)
        {
            _snackRepository = snackRepository;
            _buyCart = buyCart;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
