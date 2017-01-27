using System.Threading.Tasks;

namespace OnlineShop.Libs.Data.Contracts
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

        int SaveChanges();
    }
}
