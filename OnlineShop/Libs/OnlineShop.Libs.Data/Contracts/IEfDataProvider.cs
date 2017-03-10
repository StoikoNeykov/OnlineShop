using OnlineShop.Libs.Models;
using System.Threading.Tasks;

namespace OnlineShop.Libs.Data.Contracts
{
    public interface IEfDataProvider : IUnitOfWork
    {
        IEfQuerable<Category> Categories { get; }

        IEfQuerable<Product> Products { get; }

        IEfQuerable<PhotoItem> PhotoItems { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
