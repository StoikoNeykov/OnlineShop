using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace OnlineShop.Libs.Data.Tests.StatefulTests
{
    [TestFixture]
    public class Class_Should
    {
        [Test]
        public void Implement_Default_Interface()
        {
            var result = typeof(Stateful<DimmyClass>)
                            .GetInterfaces()
                            .SingleOrDefault(x => x == typeof(IStateful<DimmyClass>));

            Assert.IsNotNull(result);
        }

        private class DimmyClass { }
    }
}
