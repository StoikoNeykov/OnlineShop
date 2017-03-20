using OnlineShop.Configuration.Common.Constants;
using OnlineShop.Libs.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Libs.Models
{
    [Table(TablesNames.CategoryTableName)]
    public class Category : IDbModel, INameable
    {
        public Category()
        {
            this.Id = Guid.NewGuid();
            this.Products = new HashSet<Product>();
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

        public virtual ICollection<Product> Products { get; set; }
    }
}
