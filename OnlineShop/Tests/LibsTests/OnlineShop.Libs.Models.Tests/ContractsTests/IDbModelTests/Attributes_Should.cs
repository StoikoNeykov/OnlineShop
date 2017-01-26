using NUnit.Framework;
using OnlineShop.Libs.Models.Contracts;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OnlineShop.Libs.Models.Tests.ContractsTests.IDbModelTests
{
    [TestFixture]
    public class Attributes_Should
    {
        /// <summary>
        /// Fail mean class implement IDbModel and have Table attribute
        /// </summary>
        [Test]
        public void Have_Table_Attribute()
        {
            var types = AppDomain
                            .CurrentDomain
                            .GetAssemblies()
                            .SelectMany(x => x.GetTypes())
                            .Where(x => x.IsClass && !x.IsAbstract && x.GetInterfaces().Contains(typeof(IDbModel)));

            foreach (Type type in types)
            {
                var result = type
                                .GetCustomAttributes(false)
                                .Where(x => x.GetType() == typeof(TableAttribute))
                                .SingleOrDefault();

                Assert.IsNotNull(result);
            }
        }
    }
}
