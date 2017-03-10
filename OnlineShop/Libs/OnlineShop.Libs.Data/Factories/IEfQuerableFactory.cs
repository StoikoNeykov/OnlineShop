using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Models.Contracts;

namespace OnlineShop.Libs.Data.Factories
{
    public interface IEfQuerableFactory
    {
        IEfQuerable<TEntity> GetQuerable<TEntity>(IOnlineShopDbContext dbContext) where TEntity : class, IDbModel;
    }
}
