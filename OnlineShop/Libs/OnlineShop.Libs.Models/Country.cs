using OnlineShop.Libs.Models.Contracts;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using OnlineShop.Libs.Models.Constants;

namespace OnlineShop.Libs.Models
{
    [Table("Countries")]
    public class Country : IDbModel, INameable
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        [MinLength(Validation.Country.NameMinLenght)]
        [MaxLength(Validation.Country.NameMaxLenght)]
        [RegularExpression(Validation.Regexs.EnBgNumSpaceMinus)]
        public string Name { get; set; }

        [MaxLength(Validation.Country.ShortNameMaxLength)]
        public string ShortName { get; set; }
    }
}
