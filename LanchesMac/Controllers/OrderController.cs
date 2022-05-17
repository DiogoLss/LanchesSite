using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;
        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            int totalItemsOrder = 0;
            decimal totalPriceOrder = 0.0m;

            List<BuyItemsCart> items = _shoppingCart.GetBuyItemsCart();
            _shoppingCart.BuyItemsCart = items;

            //int totalItemsOrder = _shoppingCart.AllItems(); wouldn't it be a better alternative?
            //double totalPriceOrder = _shoppingCart.GetBuyCartTotal(); wouldn't it be a better alternative?

            if (_shoppingCart.BuyItemsCart.Count == 0)
            {
                ModelState.AddModelError("", "Your shopping cart is empty");
            }
            foreach (var item in items)
            {
                totalItemsOrder += item.Quantity;
                totalPriceOrder += item.Snack.Price * item.Quantity;
            }
            order.OrderItemsTotal = totalItemsOrder;
            order.TotalOrder = totalPriceOrder;
            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                ViewBag.CheckoutCompleteMessage = "Thank you for your order!";
                ViewBag.TotalOrder = _shoppingCart.GetBuyCartTotal();
                _shoppingCart.CleanCart();
                return View("~/Views/Order/CompleteCheckout.cshtml", order);
            }
            else
            {
                return View(order);
            }
        }
    }
}
