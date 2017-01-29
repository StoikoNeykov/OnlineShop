using OnlineShop.Libs.Models.Contracts;

namespace OnlineShop.Libs.Data.Tests.Mocks
{
    public class DimmyClass : IDbModel
    {
        public int Id
        {
            get { return 42; }
            set { }
        }

        public bool IsDeleted
        {
            get { return true; }
            set { }
        }
    }
}
