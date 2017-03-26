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
        private readonly IMapperService mapperService;

        public ProductService(IEfQuerable<Product> products, IEfUnitOfWork unitOfWork, IMapperService mapperService)
        {
            Guard.WhenArgument(products, nameof(products)).IsNull().Throw();
            Guard.WhenArgument(unitOfWork, nameof(unitOfWork)).IsNull().Throw();
            Guard.WhenArgument(mapperService, nameof(mapperService)).IsNull().Throw();

            this.products = products;
            this.unitOfWork = unitOfWork;
            this.mapperService = mapperService;
        }

        public IEnumerable<ProductSimpleDto> GetProducts(int page, int pageSize = 10)
        {
            Guard.WhenArgument(page, nameof(page)).IsLessThan(0).Throw();
            Guard.WhenArgument(pageSize, nameof(pageSize)).IsLessThanOrEqual(0).Throw();

            return this.products
                .Where(x => x.IsDeleted == false && x.Count > 0)
                .OrderBy(x => x.ProductId)
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList()
                .Select(x => this.mapperService.MapToSimple(x));
        }

        public void Add(ProductDto product)
        {
            Guard.WhenArgument(product, nameof(product)).IsNull().Throw();

            this.products.Add(this.mapperService.Map(product));

            this.unitOfWork.SaveChanges();
        }

        public ProductDto GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            return this.mapperService.Map(this.products
                        .FirstOrDefault(x => x.Name == name));
        }
    }
}
