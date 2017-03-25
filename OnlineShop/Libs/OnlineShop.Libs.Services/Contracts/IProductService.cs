using OnlineShop.Libs.DtoModels;
using System.Collections.Generic;

namespace OnlineShop.Libs.Services.Contracts
{
    public interface IProductService : IService
    {
        IEnumerable<ProductSimpleDto> GetProducts(int page, int pageSize = 10);
    }
}
