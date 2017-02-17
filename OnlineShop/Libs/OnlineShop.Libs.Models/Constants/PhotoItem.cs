using OnlineShop.Libs.Models.Contracts;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Libs.Models.Constants
{
    [Table("PhotoItems")]
    public class PhotoItem : IDbModel
    {
        public PhotoItem()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        [MaxLength(200)]
        public string SmallSizeUrl { get; set; }

        [Required]
        [MaxLength(200)]
        public string FullSizeUrl { get; set; }
    }
}
