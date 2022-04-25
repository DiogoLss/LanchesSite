using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [StringLength(100, ErrorMessage = "The maximum size is 100 characters.")]
        [Required(ErrorMessage ="Write category's name.")]
        [Display(Name ="Name")]
        public string CategoryName { get; set; }
        [StringLength(200, ErrorMessage = "The maximum size is 200 characters.")]
        [Required(ErrorMessage = "Write category's description.")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public List<Snack> Snacks { get; set; }

    }
}
