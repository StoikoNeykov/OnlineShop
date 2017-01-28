using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Models.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace OnlineShop.Libs.Data.Tests.ContractsTests
{
    [TestFixture]
    public class IOnlineShopDbContext_Should
    {
        [Test]
        public void HaveSetsFor_AllDbModels()
        {
            var modelsAssemblyName = "OnlineShop.Libs.Models";

            var expected = Assembly.Load(modelsAssemblyName)
                                    .GetTypes()
                                    .Where(x => x.IsClass && !x.IsAbstract && x.GetInterfaces().Contains(typeof(IDbModel)));
            ;

            var result = typeof(IOnlineShopDbContext)
                                .GetProperties()
                                .Select(x => x.PropertyType
                                            .GetGenericArguments()
                                            .SingleOrDefault());
            
            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}
