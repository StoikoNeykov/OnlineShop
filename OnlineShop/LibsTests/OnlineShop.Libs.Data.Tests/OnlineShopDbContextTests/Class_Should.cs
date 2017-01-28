using NUnit.Framework;
using OnlineShop.Libs.Data;
using System.Data.Entity;

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
    }
}
