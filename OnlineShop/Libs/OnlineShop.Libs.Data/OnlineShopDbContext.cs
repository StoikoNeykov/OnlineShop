using OnlineShop.Libs.Data.Contracts;
using System.Data.Entity;
using System;
using OnlineShop.Libs.Models;

namespace OnlineShop.Libs.Data
{
    public class OnlineShopDbContext : DbContext, IOnlineShopDbContext
    {
        // needed for add-migration 

        private static string localConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=OnlineShop;Integrated Security=True;MultipleActiveResultSets=False";

        public OnlineShopDbContext()
            : base(localConnectionString)
        {

        }

        public OnlineShopDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Product> Products { get; set; }

        public virtual IDbSet<PhotoItem> PhotoItems { get; set; }

        IDbSet<TEntity> IOnlineShopDbContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }
    }
}
