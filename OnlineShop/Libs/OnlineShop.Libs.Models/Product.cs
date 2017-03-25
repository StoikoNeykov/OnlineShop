using OnlineShop.Configuration.Common.Constants;
using OnlineShop.Libs.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Libs.Models
{
    [Table(TablesNames.ProductTableName)]
    public class Product : IDbModel, INameable
    {
        public Product()
        {
            this.Id = Guid.NewGuid();
            this.Categories = new HashSet<Category>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(Validation.ProductValidations.ProductIdMinLenght)]
        [MaxLength(Validation.ProductValidations.ProductIdMaxLenght)]
        [RegularExpression(Validation.Regexs.EnBgNumSpaceMinus)]
        public string ProductId { get; set; }

        public bool IsDeleted { get; set; }

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

        public virtual ICollection<Category> Categories { get; set; }
    }
}
