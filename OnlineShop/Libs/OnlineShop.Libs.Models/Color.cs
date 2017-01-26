using System;
using OnlineShop.Libs.Models.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Libs.Models.Constants;

namespace OnlineShop.Libs.Models
{
    [Table(TablesNames.ColorsTableName)]
    public class Color : IDbModel, INameable
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        [MinLength(Validation.Color.NameMinLenght)]
        [MaxLength(Validation.Color.NameMaxLenght)]
        [RegularExpression(Validation.Regexs.EnBgNumSpaceMinus)]
        public string Name { get; set; }

        [MaxLength(Validation.Color.HexColorMaxLength)]
        public string HexColor { get; set; }
    }
}
