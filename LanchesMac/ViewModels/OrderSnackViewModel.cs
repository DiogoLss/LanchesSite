using LanchesMac.Models;

namespace LanchesMac.ViewModels
{
    public class OrderSnackViewModel
    {
        public Order Order { get; set; }
        public IEnumerable<OrderDetail> orderDetails { get; set; }
    }
}
