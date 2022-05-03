using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ISnackRepository _snackRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(ISnackRepository snackRepository, ShoppingCart shoppingCart)
        {
            _snackRepository = snackRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            var items = _shoppingCart.GetBuyItemsCart();
            _shoppingCart.BuyItemsCart = items;

            var buyCartVM = new ShoppingCartViewModel
            {
                BuyCart = _shoppingCart,
                BuyCartTotal = _shoppingCart.GetBuyCartTotal()
            };
            return View(buyCartVM);
        }
        public IActionResult AddItemToCart(int snackId)
        {
            var selectedSnack = _snackRepository.Snacks.FirstOrDefault(x => x.SnackId == snackId);
            if(selectedSnack != null)
            {
                _shoppingCart.AddToCart(selectedSnack);
            }
            return RedirectToAction("Index");
        }
        public IActionResult RemoveItemFromCart(int snackId)
        {
            var selectedSnack = _snackRepository.Snacks.FirstOrDefault(x => x.SnackId == snackId);
            if (selectedSnack != null)
            {
                _shoppingCart.RemoveFromCart(selectedSnack);
            }
            return RedirectToAction("Index");
        }
    }
}
