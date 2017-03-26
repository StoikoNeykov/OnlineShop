using OnlineShop.Libs.DtoModels;
using OnlineShop.Libs.Models;

namespace OnlineShop.Libs.Services.Contracts
{
    public interface IMapperService : IService
    {
        ProductDto Map(Product product);

        Product Map(ProductDto product);

        ProductSimpleDto MapToSimple(Product product);
    }
}
