using NUnit.Framework;
using OnlineShop.Libs.Models.Contracts;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace OnlineShop.Libs.Models.Tests.Contracts.IDbModelTests
{
    [TestFixture]
    class Id_Should
    {
        [TestCase(0)]
        [TestCase(-300)]
        [TestCase(3444214)]
        public void GetAndSet_Should_Work(int randomNumber)
        {
            var types = AppDomain
                            .CurrentDomain
                            .GetAssemblies()
                            .SelectMany(x => x.GetTypes())
                            .Where(x => x.IsClass && !x.IsAbstract && x.GetInterfaces().Contains(typeof(IDbModel)));

            foreach (Type type in types)
            {
                var obj = (IDbModel)Activator.CreateInstance(type);

                obj.Id = randomNumber;

                Assert.AreEqual(randomNumber, obj.Id);
            }
        }

        [Test]
        public void Have_Key_Attribute()
        {
            var propertyName = "Id";

            var types = AppDomain
                            .CurrentDomain
                            .GetAssemblies()
                            .SelectMany(x => x.GetTypes())
                            .Where(x => x.IsClass && !x.IsAbstract && x.GetInterfaces().Contains(typeof(IDbModel)));

            foreach (Type type in types)
            {
                var result = type
                            .GetProperty(propertyName)
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(KeyAttribute))
                            .SingleOrDefault();

                Assert.IsNotNull(result);
            }
        }
    }
}
