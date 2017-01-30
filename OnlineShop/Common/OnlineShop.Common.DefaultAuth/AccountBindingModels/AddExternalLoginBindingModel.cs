using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Common.DefaultAuth.AccountBindingModels
{
    public class AddExternalLoginBindingModel
    {
        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }
    }
}
