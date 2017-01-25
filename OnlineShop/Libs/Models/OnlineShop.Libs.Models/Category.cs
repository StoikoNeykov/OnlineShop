using OnlineShop.Libs.Models.Constants;
using OnlineShop.Libs.Models.Contracts;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Libs.Models
{
    [Table(TablesNames.CategoryTablename)]
    public class Category : IDbModel, INameable
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        [MinLength(Validation.Category.NameMinLenght)]
        [MaxLength(Validation.Category.NameMaxLenght)]
        [RegularExpression(Validation.Regexs.EnBgNumSpaceMinus)]
        public string Name { get; set; }
    }
}
