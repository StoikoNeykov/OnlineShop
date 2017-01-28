using OnlineShop.Libs.Data.Contracts;
using System.Data.Entity.Infrastructure;

namespace OnlineShop.Libs.Data.Factories
{
    public interface IStatefulFactory
    {
        IStateful<T> GetStateful<T>(DbEntityEntry<T> entry) where T : class;
    }
}
