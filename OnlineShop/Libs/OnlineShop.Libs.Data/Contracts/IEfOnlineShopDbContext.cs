using OnlineShop.Libs.Models;
using OnlineShop.Libs.Models.Contracts;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace OnlineShop.Libs.Data.Contracts
{
    public interface IEfOnlineShopDbContext : IEfEntryProvider, IEfUnitOfWork
    {
        IDbSet<TEntity> GetSet<TEntity>() where TEntity : class, IDbModel;
        
        Task<int> SaveChangesAsync();

        int SaveChanges();

        IDbSet<Category> Categories { get; }

        IDbSet<Product> Products { get; }
    }
}
