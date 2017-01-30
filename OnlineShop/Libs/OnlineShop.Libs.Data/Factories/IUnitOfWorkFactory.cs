using OnlineShop.Libs.Data.Contracts;

namespace OnlineShop.Libs.Data.Factories
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork GetUnitOfWork();
    }
}
