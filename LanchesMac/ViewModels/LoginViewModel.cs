using System.ComponentModel.DataAnnotations;

namespace LanchesMac.ViewModels
{
    public class LoginViewModel
    {
         [Required(ErrorMessage="Inform your name")]
         [Display(Name="User")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Inform your password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
