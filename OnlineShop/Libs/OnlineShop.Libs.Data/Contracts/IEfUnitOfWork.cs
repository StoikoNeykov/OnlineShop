using System;
using System.Threading.Tasks;

namespace OnlineShop.Libs.Data.Contracts
{
    public interface IEfUnitOfWork
    {
        int SaveChanges();
    }
}
