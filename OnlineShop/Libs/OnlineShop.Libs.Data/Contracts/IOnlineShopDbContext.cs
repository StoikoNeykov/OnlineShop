using OnlineShop.Libs.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace OnlineShop.Libs.Data.Contracts
{
    public interface IOnlineShopDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        IStateful<TEntity> GetStateful<TEntity>(TEntity entity) where TEntity : class;

        Task<int> SaveChangesAsync();

        int SaveChanges();

        IDbSet<Category> Categories { get; }

        IDbSet<Product> Products { get; }

        IDbSet<PhotoItem> PhotoItems { get; }
    }
}
