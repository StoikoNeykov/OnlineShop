using NUnit.Framework;
using OnlineShop.Libs.Data;
using OnlineShop.Libs.Data.Contracts;
using System.Data.Entity;
using System.Linq;

namespace OnlineShop.Libs.Data.Tests.OnlineShopDbContextTests
{
    [TestFixture]
    public class Class_Should
    {
        [Test]
        public void Inherit_EfDbContext()
        {
            var result = typeof(OnlineShopDbContext)
                                .BaseType;

            Assert.AreEqual(typeof(DbContext), result);
        }

        [Test]
        public void Implement_IOnlineShopDbContext()
        {
            var result = typeof(OnlineShopDbContext)
                            .GetInterfaces()
                            .SingleOrDefault(x => x == typeof(IOnlineShopDbContext));

            Assert.IsNotNull(result);
        }
    }
}
