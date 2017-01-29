using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using System.Linq;

namespace OnlineShop.Libs.Data.Tests.UnitOfWorkTests
{
    [TestFixture]
    public class Class_Should
    {
        [Test]
        public void Implement_Default_Interface()
        {
            var result = typeof(UnitOfWork)
                            .GetInterfaces()
                            .SingleOrDefault(x => x == typeof(IUnitOfWork));

            Assert.IsNotNull(result);
        }
    }
}
