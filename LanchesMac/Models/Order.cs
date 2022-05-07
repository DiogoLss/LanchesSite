using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required(ErrorMessage ="Informe the name.")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Informe the last name.")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Informe the address.")]
        [StringLength(100)]
        [Display(Name ="Address")]
        public string Address1 { get; set; }
        [Required(ErrorMessage = "Informe the complement.")]
        [StringLength(100)]
        [Display(Name = "Complement")]
        public string Address2 { get; set; }
        [Required(ErrorMessage = "Informe the CEP.")]
        [StringLength(10, MinimumLength = 8)]
        [Display(Name = "CEP")]
        public string Cep { get; set; }
        [StringLength(10)]
        public string State { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [Required(ErrorMessage = "Informe the cellphone's number.")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Informe the email.")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "The email's format is not correct")]
        public string Email { get; set; }
        [ScaffoldColumn(false)]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Order's total")]
        public decimal TotalOrder { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Order's Items")]
        public int OrderItemsTotal { get; set; }

        [Display(Name = "Order's Date")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime OrderSent { get; set; }

        [Display(Name = "Order sent date")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? OrderDelivered { get; set; }

        public List<OrderDetail> OrderItems { get; set; }
    }
}
