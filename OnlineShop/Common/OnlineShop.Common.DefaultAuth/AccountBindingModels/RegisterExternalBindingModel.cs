using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Common.DefaultAuth.AccountBindingModels
{
    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
