namespace OnlineShop.Libs.Models.Contracts
{
    public interface IDbModel
    {
        int Id { get; set; }

        bool IsDeleted { get; set; }
    }
}
