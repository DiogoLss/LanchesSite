using LanchesMac.Models;

namespace LanchesMac.ViewModels
{
    public class SnackListViewModel
    {
        public IEnumerable<Snack> Snacks { get; set; }
        public string CurrentCategory { get; set; }

    }
}
