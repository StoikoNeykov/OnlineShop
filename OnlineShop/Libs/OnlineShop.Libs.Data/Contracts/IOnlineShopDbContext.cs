using System.Data.Entity;
using System.Threading.Tasks;

namespace OnlineShop.Libs.Data.Contracts
{
    public interface IOnlineShopDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        IStateful<TEntity> GetStateful<TEntity>(TEntity entity) where TEntity : class;

        Task<int> SaveChangesAsync();

        int SaveChanges();
    }
}
