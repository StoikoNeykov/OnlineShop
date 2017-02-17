using OnlineShop.Libs.Models.Constants;
using OnlineShop.Libs.Models.Contracts;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace OnlineShop.Libs.Models
{
    [Table(TablesNames.CategoryTableName)]
    public class Category : IDbModel, INameable
    {
        public Category()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        [MinLength(Validation.CategoryValidations.NameMinLenght)]
        [MaxLength(Validation.CategoryValidations.NameMaxLenght)]
        [RegularExpression(Validation.Regexs.EnBgNumSpaceMinus)]
        public string Name { get; set; }
    }
}
