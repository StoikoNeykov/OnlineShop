using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Models;
using OnlineShop.Libs.Models.Contracts;
using System.Data.Entity;

namespace OnlineShop.Libs.Data
{
    public class OnlineShopEfDbContext : DbContext, IOnlineShopEfDbContext
    {
        // needed for add-migration 

        //private static string localConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=OnlineShop;Integrated Security=True;MultipleActiveResultSets=False";

        //public OnlineShopDbContext()
        //    : base(localConnectionString)
        //{

        //}

        public OnlineShopEfDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Product> Products { get; set; }

        public virtual IDbSet<PhotoItem> PhotoItems { get; set; }

        public IDbSet<TEntity> GetSet<TEntity>() where TEntity : class, IDbModel
        {
            return base.Set<TEntity>();
        }
    }
}
