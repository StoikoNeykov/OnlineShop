using System;
using NUnit.Framework;
using OnlineShop.Libs.Models.Contracts;
using OnlineShop.Libs.Data.Contracts;
using System.Linq;

namespace OnlineShop.Libs.Data.Tests.RepositoryTests
{
    [TestFixture]
    public class Class_Should
    {
        [Test]
        public void Implement_Default_Interface()
        {
            var result = typeof(Repository<IDbModel>)
                                .GetInterfaces()
                                .SingleOrDefault(x => x == typeof(IRepository<IDbModel>));

            Assert.IsNotNull(result);
        }
    }
}
