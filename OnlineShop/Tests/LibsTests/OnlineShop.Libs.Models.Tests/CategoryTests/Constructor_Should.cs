using NUnit.Framework;

namespace OnlineShop.Libs.Models.Tests.CategoryTests
{
    [TestFixture]
    class Constructor_Should
    {
        [Test]
        public void NotSet_Name()
        {
            var obj = new Category();

            Assert.AreEqual(null, obj.Name);
        }
    }
}
