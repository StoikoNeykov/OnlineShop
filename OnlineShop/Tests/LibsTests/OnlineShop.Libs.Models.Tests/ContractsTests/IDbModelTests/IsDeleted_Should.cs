using NUnit.Framework;
using OnlineShop.Libs.Models.Contracts;
using System;
using System.Linq;

namespace OnlineShop.Libs.Models.Tests.ContractsTests.IDbModelTests
{
    [TestFixture]
    public class IsDeleted_Should
    {
        [TestCase(true)]
        [TestCase(false)]
        public void GetAndSet_Should_Work(bool value)
        {
            var types = AppDomain
                           .CurrentDomain
                           .GetAssemblies()
                           .SelectMany(x => x.GetTypes())
                           .Where(x => x.IsClass && !x.IsAbstract && x.GetInterfaces().Contains(typeof(IDbModel)));

            foreach(Type type in types)
            {
                var obj = (IDbModel)Activator.CreateInstance(type);

                obj.IsDeleted = value;

                Assert.AreEqual(value, obj.IsDeleted);
            }
        }
    }
}
