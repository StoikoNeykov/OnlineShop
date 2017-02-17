using NUnit.Framework;
using OnlineShop.Libs.Models.Contracts;
using System;
using System.Linq;

namespace OnlineShop.Libs.Models.Tests.ContractsTests.IDbModelTests
{
    [TestFixture]
    public class ParameterlessConstructor_Should
    {
        [Test]
        public void Exist()
        {
            var types = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => x.IsClass && !x.IsAbstract && x.GetInterfaces().Contains(typeof(IDbModel)));

            foreach (Type type in types)
            {
                var obj = (IDbModel)Activator.CreateInstance(type);

                Assert.IsInstanceOf<IDbModel>(obj);
            }
        }

        [Test]
        public void Set_Id()
        {
            var types = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => x.IsClass && !x.IsAbstract && x.GetInterfaces().Contains(typeof(IDbModel)));

            foreach (Type type in types)
            {
                var obj = (IDbModel)Activator.CreateInstance(type);

                Assert.AreNotEqual(Guid.Empty, obj.Id);
            }
        }

        [Test]
        public void NotSet_IsDeleted()
        {
            var types = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => x.IsClass && !x.IsAbstract && x.GetInterfaces().Contains(typeof(IDbModel)));

            foreach (Type type in types)
            {
                var obj = (IDbModel)Activator.CreateInstance(type);

                Assert.AreEqual(false, obj.IsDeleted);
            }
        }
    }
}
