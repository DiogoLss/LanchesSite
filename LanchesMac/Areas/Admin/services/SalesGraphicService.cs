using LanchesMac.Context;
using LanchesMac.Models;

namespace LanchesMac.Areas.Admin.services
{
    public class SalesGraphicService
    {
        private readonly AppDbContext _context;

        public SalesGraphicService(AppDbContext context)
        {
            _context = context;
        }
        public List<SnackGraphic> GetSnackSales(int days = 360)
        {
            var date = DateTime.Now.AddDays(-days);

            var snacks = (from od in _context.OrderDetails
                          join s in _context.Snacks on od.SnackId equals s.SnackId
                          where od.Order.OrderSent >= date
                          group od by new { od.SnackId, s.Name}
                          into g
                          select new
                          {
                              SnackName = g.Key.Name,
                              SnacksQuantity = g.Sum(q => q.Quantity),
                              SnacksTotalValue = g.Sum(t => t.Price * t.Quantity)
                          });
            var list = new List<SnackGraphic>();

            foreach (var item in snacks)
            {
                var snack = new SnackGraphic();
                snack.SnackName = item.SnackName;
                snack.SnacksQuantity = item.SnacksQuantity;
                snack.SnacksTotalValue = item.SnacksTotalValue;
                list.Add(snack);
            }
            return list;
        }
    }
}
