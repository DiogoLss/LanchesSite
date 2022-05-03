using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModels;
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
            var items = _buyCart.GetBuyItemsCart();
            _buyCart.BuyItemsCart = items;

            var buyCartVM = new BuyCartViewModel
            {
                BuyCart = _buyCart,
                BuyCartTotal = _buyCart.GetBuyCartTotal()
            };
            return View(buyCartVM);
        }
        public IActionResult AddItemToCart(int snackId)
        {
            var selectedSnack = _snackRepository.Snacks.FirstOrDefault(x => x.SnackId == snackId);
            if(selectedSnack != null)
            {
                _buyCart.AddToCart(selectedSnack);
            }
            return RedirectToAction("Index");
        }
        public IActionResult RemoveItemFromCart(int snackId)
        {
            var selectedSnack = _snackRepository.Snacks.FirstOrDefault(x => x.SnackId == snackId);
            if (selectedSnack != null)
            {
                _buyCart.RemoveFromCart(selectedSnack);
            }
            return RedirectToAction("Index");
        }
    }
}
