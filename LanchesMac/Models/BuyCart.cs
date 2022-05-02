using LanchesMac.Context;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Models
{
    public class BuyCart
    {
        private readonly AppDbContext _context;

        public BuyCart(AppDbContext context)
        {
            _context = context;
        }

        public string BuyCartId { get; set; }
        public List<BuyItemsCart> BuyItemsCart { get; set; }

        public static BuyCart GetCart(IServiceProvider services)
        {
            //define uma sessão
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            //obtem um serviço do tipo do nosso contexto
            var context = services.GetService<AppDbContext>();
            //obtem ou gera id do carrinho
            string cartId = session.GetString("cartId") ?? Guid.NewGuid().ToString();
            //atribui o id do carrinho na sessão
            session.SetString("cartId", cartId);

            //retorna o carrinho com o contexto e o Id atribuido ou obtido
            return new BuyCart(context)
            {
                BuyCartId = cartId
            };
        }
        public void AddToCart(Snack snack)
        {
            var buyItemCart = _context.BuyItemsCart.SingleOrDefault(
                s => s.Snack.SnackId == snack.SnackId && s.BuyCartId == BuyCartId);
            if(buyItemCart == null)
            {
                buyItemCart = new BuyItemsCart
                {
                    BuyCartId = BuyCartId,
                    Snack = snack,
                    Quantity = 1
                };
                _context.BuyItemsCart.Add(buyItemCart);
            }
            else
            {
                buyItemCart.Quantity++;
            }
            _context.SaveChanges();
        }
        public int RemoveFromCart(Snack snack)
        {
            var butItemCart = _context.BuyItemsCart.SingleOrDefault(
                s => s.Snack.SnackId == snack.SnackId && s.BuyCartId == BuyCartId);

            var thisQuantity = 0;

            if(butItemCart != null)
            {
                if(butItemCart.Quantity > 1)
                {
                    butItemCart.Quantity--;
                    thisQuantity = butItemCart.Quantity;
                }
                else
                {
                    _context.BuyItemsCart.Remove(butItemCart);
                }
            }
            _context.SaveChanges();
            return thisQuantity;
        }
        public List<BuyItemsCart> GetBuyItemsCart()
        {
            return BuyItemsCart ??
                (BuyItemsCart = _context.BuyItemsCart
                .Where(c => c.BuyCartId == BuyCartId)
                .Include(s => s.Snack)
                .ToList());
        }
        public void CleanCart()
        {
            var cartItems = _context.BuyItemsCart.Where(c => c.BuyCartId == BuyCartId);
            _context.BuyItemsCart.RemoveRange(cartItems);
            _context.SaveChanges();
        }
        public double GetBuyCartTotal()
        {
            var total = _context.BuyItemsCart
                .Where(c => c.BuyCartId == BuyCartId)
                .Select(c => c.Snack.Price * c.Quantity)
                .Sum();
            return total;
        }
    }
}
