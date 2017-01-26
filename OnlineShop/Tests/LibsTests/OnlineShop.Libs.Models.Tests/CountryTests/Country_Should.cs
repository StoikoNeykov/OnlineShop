using NUnit.Framework;
using OnlineShop.Libs.Models.Constants;
using OnlineShop.Libs.Models.Contracts;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OnlineShop.Libs.Models.Tests.CountryTests
{
    [TestFixture]
    public class Country_Should
    {
        [Test]
        public void Have_RightValueFor_TableAttribute()
        {
            var result = typeof(Country)
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(TableAttribute))
                            .Select(x => (TableAttribute)x)
                            .Single()
                            .Name;

            Assert.AreEqual(TablesNames.CountryTableName, result);

        }

        [Test]
        public void Implement_IDbModel()
        {
            var result = typeof(Country)
                            .GetInterfaces()
                            .SingleOrDefault(x => x == typeof(IDbModel));

            Assert.IsNotNull(result);
        }

        [Test]
        public void Implement_INameable()
        {
            var result = typeof(Country)
                            .GetInterfaces()
                            .SingleOrDefault(x => x == typeof(INameable));

            Assert.IsNotNull(result);
        }
    }
}
