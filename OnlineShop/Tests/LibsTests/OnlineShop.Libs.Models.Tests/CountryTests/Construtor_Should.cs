using NUnit.Framework;

namespace OnlineShop.Libs.Models.Tests.CountryTests
{
    [TestFixture]
    public class Construtor_Should
    {
        [Test]
        public void NotSet_Name()
        {
            var obj = new Country();

            Assert.AreEqual(null, obj.Name);
        }

        [Test]
        public void NotSet_ShortName()
        {
            var obj = new Country();

            Assert.AreEqual(null, obj.ShortName);
        }
    }
}
