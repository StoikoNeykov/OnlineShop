using Bytes2you.Validation;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.DtoModels;
using OnlineShop.Libs.Models;
using OnlineShop.Libs.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Libs.Services
{
    public class ProductService : IProductService, IService
    {
        private readonly IEfQuerable<Product> products;

        public ProductService(IEfQuerable<Product> products)
        {
            Guard.WhenArgument(products, nameof(products)).IsNull().Throw();

            this.products = products;
        }

        public IEnumerable<ProductSimpleDto> GetProducts(int page, int pageSize = 10)
        {
            return this.products
                .Include(x => x.Photos)
                .Where(x => x.IsDeleted == false && x.Count > 0)
                .OrderBy(x=>x.ProductId)
                .Skip(page * pageSize)
                .Take(pageSize)
                .Select(x => new ProductSimpleDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    ImageUrl = x.Photos.FirstOrDefault().SmallSizeUrl,
                    Link = @"/products/" + x.Name
                })
                .ToList();
        }
    }
}
