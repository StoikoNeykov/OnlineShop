using System;
using System.Threading.Tasks;

namespace OnlineShop.Libs.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();

        int SaveChanges();
    }
}
