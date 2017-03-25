using OnlineShop.Configuration.Common.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Clients.MVC.Areas.Admin.Models
{
    public class AddProduct
    {
        [Required]
        [MinLength(Validation.ProductValidations.ProductIdMinLenght)]
        [MaxLength(Validation.ProductValidations.ProductIdMaxLenght)]
        [RegularExpression(Validation.Regexs.EnBgNumSpaceMinus)]
        public string ProductId { get; set; }

        [Required]
        [MinLength(Validation.ProductValidations.NameMinLenght)]
        [MaxLength(Validation.ProductValidations.NameMaxLenght)]
        [RegularExpression(Validation.Regexs.EnBgNumSpaceMinus)]
        public string Name { get; set; }

        [Range(0.0, 1000000000)]
        public decimal Price { get; set; }

        public int Count { get; set; }

        [Required]
        public string Photo1 { get; set; }

        public string Photo2 { get; set; }

        public string Photo3 { get; set; }

        public string Photo4 { get; set; }
    }
}