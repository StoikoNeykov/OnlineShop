using OnlineShop.Libs.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace OnlineShop.Libs.Data.Contracts
{
    public interface IOnlineShopDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        Task<int> SaveChangesAsync();

        int SaveChanges();

        IDbSet<Category> Categories { get; }

        IDbSet<Product> Products { get; }

        IDbSet<PhotoItem> PhotoItems { get; }
    }
}
