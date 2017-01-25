using NUnit.Framework;
using OnlineShop.Libs.Models;
using OnlineShop.Libs.Models.Constants;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OnlineShop.Libs.Models.Tests.ColorTests
{
    [TestFixture]
    public class Color_Should
    {
        [Test]
        public void Have_Table_Attribute()
        {
            var result = typeof(Color)
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(TableAttribute))
                            .SingleOrDefault();

            Assert.IsNotNull(result);
        }

        [Test]
        public void Have_RightValueFor_TableAttribute()
        {
            var result = typeof(Color)
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(TableAttribute))
                            .Select(x => (TableAttribute)x)
                            .Single()
                            .Name;

            Assert.AreEqual(TablesNames.ColorsTableName, result);

        }
    }
}
