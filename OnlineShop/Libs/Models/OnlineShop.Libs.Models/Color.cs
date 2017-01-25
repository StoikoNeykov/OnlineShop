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

        public string Name { get; set; }

        public string HexColor { get; set; }
    }
}
