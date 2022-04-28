using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("BuyItemsCart")]
    public class BuyItemsCart
    {
        [Key]
        public int BuyItemCartId { get; set; }
        public Snack Snack { get; set; }
        public int Quantity { get; set; }
        [StringLength(200)]
        public string BuyCartId { get; set; }

    }
}
