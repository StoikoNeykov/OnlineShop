using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Models;
using OnlineShop.Libs.Models.Contracts;
using System.Data.Entity;

namespace OnlineShop.Libs.Data
{
    public class EfOnlineShopDbContext : DbContext, IEfOnlineShopDbContext, IEfUnitOfWork
    {
        // needed for add-migration 

        private static string localConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=OnlineShop;Integrated Security=True;MultipleActiveResultSets=False";

        public EfOnlineShopDbContext()
            : base(localConnectionString)
        {

        }

        public EfOnlineShopDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Product> Products { get; set; }

        public IDbSet<TEntity> GetSet<TEntity>() where TEntity : class, IDbModel
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(x => x.Categories)
                .WithMany(x => x.Products)
                .Map(cp =>
                {
                    cp.MapLeftKey("ProductId");
                    cp.MapRightKey("CategoryId");
                    cp.ToTable("ProductsCategories");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
