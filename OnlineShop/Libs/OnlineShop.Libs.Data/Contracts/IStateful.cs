using System.Data.Entity;

namespace OnlineShop.Libs.Data.Contracts
{
    public interface IStateful<T>
    {
        EntityState State { get; set; }

    }
}
