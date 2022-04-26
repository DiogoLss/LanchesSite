using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;

namespace LanchesMac.Repositories
{
    public class SnackRepository : ISnackRepository
    {
        private readonly AppDbContext _context;
        public SnackRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Snack> Snacks => throw new NotImplementedException();

        public IEnumerable<Snack> FavoriteSnacks => throw new NotImplementedException();

        public Snack GetSnackById(int snackId)
        {
            throw new NotImplementedException();
        }
    }
}
