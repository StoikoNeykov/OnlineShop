using System;

namespace OnlineShop.Libs.Models.Contracts
{
    public interface IDbModel
    {
        Guid Id { get; set; }

        bool IsDeleted { get; set; }
    }
}
