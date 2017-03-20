using Bytes2you.Validation;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Models;
using OnlineShop.Libs.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Libs.Services
{
    public class ProductService : IProductService
    {
        private readonly IEfQuerable<Product> products;

        public ProductService(IEfDataProvider dataProvider)
        {
            Guard.WhenArgument(dataProvider, nameof(dataProvider)).IsNull().Throw();

            this.products = dataProvider.Products;
        }

        public IEnumerable<Product> GetProducts(int page, int pageSize = 10)
        {
            return this.products
                .GetAvailabe
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
