using System;
using OnlineShop.Libs.Models.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Libs.Models.Constants;
using System.Collections.Generic;

namespace OnlineShop.Libs.Models
{
    [Table(TablesNames.ProductTableName)]
    public class Product : IDbModel, INameable
    {
        public Product()
        {
            this.Id = Guid.NewGuid();
            this.Photos = new HashSet<PhotoItem>();
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

        [Required]
        [MinLength(Validation.ProductValidations.NameMinLenght)]
        [MaxLength(Validation.ProductValidations.NameMaxLenght)]
        [RegularExpression(Validation.Regexs.EnBgNumSpaceMinus)]
        public string FullName { get; set; }

        public virtual ICollection<PhotoItem> Photos { get; set; }

        [Range(0.0, 1000000000)]
        public decimal Price { get; set; }

        public int Count { get; set; }
    }
}
