using Bytes2you.Validation;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data.Factories;
using OnlineShop.Libs.Models;
using System.Threading.Tasks;

namespace OnlineShop.Libs.Data
{
    public class EfDataProvider : IEfDataProvider
    {
        private readonly IEfOnlineShopDbContext dbContext;
        private readonly IEfQuerableFactory querableFactory;

        public EfDataProvider(IEfOnlineShopDbContext dbContext, IEfQuerableFactory querableFactory)
        {
            Guard.WhenArgument(dbContext, nameof(dbContext)).IsNull().Throw();
            Guard.WhenArgument(querableFactory, nameof(querableFactory)).IsNull().Throw();

            this.dbContext = dbContext;
            this.querableFactory = querableFactory;
        }

        public virtual IEfQuerable<Category> Categories 
            => this.querableFactory.GetQuerable<Category>(this.dbContext);

        public virtual IEfQuerable<Product> Products 
            => this.querableFactory.GetQuerable<Product>(this.dbContext);

        public virtual IEfQuerable<PhotoItem> PhotoItems 
            => this.querableFactory.GetQuerable<PhotoItem>(this.dbContext);

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
