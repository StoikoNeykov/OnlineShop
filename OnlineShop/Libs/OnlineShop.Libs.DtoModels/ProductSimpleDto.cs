using System;

namespace OnlineShop.Libs.DtoModels
{
    public class ProductSimpleDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string Link { get; set; }
    }
}
