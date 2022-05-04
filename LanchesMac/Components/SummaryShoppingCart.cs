using LanchesMac.Models;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Components
{
    public class SummaryShoppingCart : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public SummaryShoppingCart(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetBuyItemsCart();
            _shoppingCart.BuyItemsCart = items;

            var buyCartVM = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetBuyCartTotal()
            };
            return View(buyCartVM);
        }
    }
}
