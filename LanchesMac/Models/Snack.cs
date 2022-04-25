using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Snacks")]
    public class Snack
    {
        //key
        [Key]
        public int SnackId { get; set; }
        //Name

        [Required(ErrorMessage ="Snack's name must be informed.")]
        [Display(Name ="Snack name.")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "the {0} must have at least {1} and a maximum of {2} characters.")]
        public string Name { get; set; }

        //Short Description
        [Required(ErrorMessage = "Snack's description must be informed.")]
        [Display(Name = "Snack's description.")]
        [MinLength(20, ErrorMessage ="The description must have at least {1} characters.")]
        [MaxLength(200, ErrorMessage ="the description must have a maximum of {1} characters.")]
        public string ShortDescription { get; set; }
        //Detailed Description

        [Required(ErrorMessage = "Snack's description must be informed.")]
        [Display(Name = "Snack's detailed description.")]
        [MinLength(20, ErrorMessage = "The description must have at least {1} characters.")]
        [MaxLength(200, ErrorMessage = "the description must have a maximum of {1} characters.")]
        public string DetailedDescription { get; set; }
        //Price
        [Required(ErrorMessage ="Inform snack's price")]
        [Display(Name="Price")]
        [Column(TypeName ="decimal(6,2)")]
        [Range(1,999.99, ErrorMessage ="Price must be among 1 and 999.99")]
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsFavoriteSnack { get; set; }
        public bool InStock { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }  
    }
}
