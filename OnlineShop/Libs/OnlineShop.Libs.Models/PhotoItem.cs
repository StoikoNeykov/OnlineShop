using OnlineShop.Libs.Models.Contracts;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using OnlineShop.Configuration.Common.Constants;

namespace OnlineShop.Libs.Models
{
    [Table(TablesNames.PhotoItemTableName)]
    public class PhotoItem : IDbModel
    {
        public PhotoItem()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        [MaxLength(Validation.PhotoItemValidations.SmallSizeUrlMaxLenght)]
        public string SmallSizeUrl { get; set; }

        [Required]
        [MaxLength(Validation.PhotoItemValidations.FullSizeUrlMaxLenght)]
        public string FullSizeUrl { get; set; }
    }
}
