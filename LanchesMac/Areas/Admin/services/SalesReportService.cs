using LanchesMac.Context;
using LanchesMac.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Areas.Admin.services
{
    public class SalesReportService
    {
        private readonly AppDbContext _context;
        public SalesReportService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.Orders select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.OrderSent >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.OrderSent <= maxDate.Value);
            }
            return await result
                .Include(s => s.OrderItems)
                .ThenInclude(s=>s.Snack)
                .OrderByDescending(x => x.OrderSent)
                .ToListAsync();
        }
    }
}
