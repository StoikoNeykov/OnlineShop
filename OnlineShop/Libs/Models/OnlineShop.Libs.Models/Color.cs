using System;
using OnlineShop.Libs.Models.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Libs.Models
{
    [Table("Colours")]
    public class Color : IDbModel
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Name { get; set; }

        public string HexColor { get; set; }
    }
}
