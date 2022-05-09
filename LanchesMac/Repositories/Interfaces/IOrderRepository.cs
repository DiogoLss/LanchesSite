using LanchesMac.Models;

namespace LanchesMac.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
