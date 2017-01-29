using System;
using System.Threading.Tasks;
using OnlineShop.Libs.Data.Contracts;

namespace OnlineShop.Libs.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IOnlineShopDbContext dbContext;

        public UnitOfWork(IOnlineShopDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("OnlineShopDbContext");
            }

            this.dbContext = dbContext;
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return this.dbContext.SaveChangesAsync();
        }
    }
}
