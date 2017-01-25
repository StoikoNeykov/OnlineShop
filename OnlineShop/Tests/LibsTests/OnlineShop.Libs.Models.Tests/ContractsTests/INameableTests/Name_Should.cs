using NUnit.Framework;
using OnlineShop.Libs.Models.Contracts;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OnlineShop.Libs.Models.Tests.ContractsTests.INameableTests
{
    [TestFixture]
    public class Name_Should
    {
        [Test]
        public void Have_Validation_Attributes()
        {
            var propertyName = "Name";

            var types = AppDomain
                            .CurrentDomain
                            .GetAssemblies()
                            .SelectMany(x => x.GetTypes())
                            .Where(x => x.IsClass && !x.IsAbstract && x.GetInterfaces().Contains(typeof(INameable)));

            foreach (Type type in types)
            {
                var result = type
                                .GetProperty(propertyName)
                                .GetCustomAttributes(false)
                                .Select(x => x.GetType());

                CollectionAssert.Contains(result, typeof(RequiredAttribute));
                CollectionAssert.Contains(result, typeof(MinLengthAttribute));
                CollectionAssert.Contains(result, typeof(MaxLengthAttribute));
                CollectionAssert.Contains(result, typeof(RegularExpressionAttribute));
            }
        }

        [TestCase("")]
        [TestCase("123")]
        [TestCase("dfs,kjcfl.jdscl;fsd")]
        [TestCase("not a string")]
        [TestCase("@#@##$><$#@><!@#<!>")]
        public void GetAndSet_Should_Work(string randomString)
        {
            var types = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => x.IsClass && !x.IsAbstract && x.GetInterfaces().Contains(typeof(INameable)));

            foreach (Type type in types)
            {
                var obj = (INameable)Activator.CreateInstance(type);

                obj.Name = randomString;

                Assert.AreEqual(randomString, obj.Name);
            }
        }
    }
}
