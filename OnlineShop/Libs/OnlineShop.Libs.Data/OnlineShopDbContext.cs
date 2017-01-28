using OnlineShop.Libs.Data.Contracts;
using System.Data.Entity;
using System;
using OnlineShop.Libs.Data.Factories;
using OnlineShop.Libs.Models;

namespace OnlineShop.Libs.Data
{
    public class OnlineShopDbContext : DbContext, IOnlineShopDbContext
    {
        private readonly IStatefulFactory statefulFactory;

        public OnlineShopDbContext(string connectionString, IStatefulFactory statefulFactory)
            : base(connectionString)
        {
            if (statefulFactory == null)
            {
                throw new ArgumentNullException("StatefulFactory");
            }

            this.statefulFactory = statefulFactory;
        }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Color> Colors { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

        IDbSet<TEntity> IOnlineShopDbContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }

        public IStateful<TEntity> GetStateful<TEntity>(TEntity entity) where TEntity : class
        {
            return this.statefulFactory.GetStateful(this.Entry(entity));
        }
    }
}
