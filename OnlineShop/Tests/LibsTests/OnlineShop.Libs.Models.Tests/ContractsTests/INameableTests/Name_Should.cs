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
        /// <summary>
        /// Fail mean class that implement INameable dont have validation attributes
        /// </summary>
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
             
                CollectionAssert.Contains(result, typeof(RequiredAttribute), message: $"{type.Name} does not have Required attribute");
                CollectionAssert.Contains(result, typeof(MinLengthAttribute), message: $"{type.Name} does not have MinLength attribute");
                CollectionAssert.Contains(result, typeof(MaxLengthAttribute), message: $"{type.Name} does not have MaxLength attribute");
                CollectionAssert.Contains(result, typeof(RegularExpressionAttribute), message: $"{type.Name} does not have RegularExpression attribute");
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
