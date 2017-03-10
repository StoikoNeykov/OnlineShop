using System.Data.Entity.Infrastructure;

namespace OnlineShop.Libs.Data.Contracts
{
    public interface IEfEntryProvider
    {
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
