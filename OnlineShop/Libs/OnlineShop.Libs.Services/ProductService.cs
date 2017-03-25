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
        private readonly IEfUnitOfWork unitOfWork;

        public ProductService(IEfQuerable<Product> products, IEfUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(products, nameof(products)).IsNull().Throw();
            Guard.WhenArgument(unitOfWork, nameof(unitOfWork)).IsNull().Throw();

            this.products = products;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<ProductSimpleDto> GetProducts(int page, int pageSize = 10)
        {
            return this.products
                .Where(x => x.IsDeleted == false && x.Count > 0)
                .OrderBy(x => x.ProductId)
                .Skip(page * pageSize)
                .Take(pageSize)
                .Select(x => new ProductSimpleDto
                {
                    Id = x.ProductId,
                    Name = x.Name,
                    Price = x.Price,
                    ImageUrl = x.Photo1,
                    Link = @"/products/" + x.Name
                })
                .ToList();
        }

        public void Add(AddProductDto product)
        {
            this.products.Add(new Product()
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Count = product.Count,
                Price = product.Price,
                Photo1 = product.Photo1,
                Photo2 = product.Photo2,
                Photo3 = product.Photo3,
                Photo4 = product.Photo4
            });

            this.unitOfWork.SaveChanges();
        }
    }
}
