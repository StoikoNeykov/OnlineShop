using OnlineShop.Libs.Models;
using System.Collections.Generic;

namespace OnlineShop.Libs.Services.Contracts
{
    public interface IProductService : IService
    {
        IEnumerable<Product> GetProducts(int page, int pageSize = 10);
    }
}
