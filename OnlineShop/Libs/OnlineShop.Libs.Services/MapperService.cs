using Bytes2you.Validation;
using OnlineShop.Libs.DtoModels;
using OnlineShop.Libs.Models;
using OnlineShop.Libs.Services.Contracts;

namespace OnlineShop.Libs.Services
{
    public class MapperService : IMapperService, IService
    {
        public ProductDto Map(Product product)
        {
            Guard.WhenArgument(product, nameof(product)).IsNull().Throw();

            return new ProductDto()
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Count = product.Count,
                Price = product.Price,
                Photo1 = product.Photo1,
                Photo2 = product.Photo2,
                Photo3 = product.Photo3,
                Photo4 = product.Photo4
            };
        }

        public Product Map(ProductDto product)
        {
            Guard.WhenArgument(product, nameof(product)).IsNull().Throw();

            return new Product()
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Count = product.Count,
                Price = product.Price,
                Photo1 = product.Photo1,
                Photo2 = product.Photo2,
                Photo3 = product.Photo3,
                Photo4 = product.Photo4
            };
        }

        public ProductSimpleDto MapToSimple(Product product)
        {
            Guard.WhenArgument(product, nameof(product)).IsNull().Throw();

            return new ProductSimpleDto
            {
                Id = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                ImageUrl = product.Photo1,
                Link = @"/" + product.Name
            };
        }
    }
}
