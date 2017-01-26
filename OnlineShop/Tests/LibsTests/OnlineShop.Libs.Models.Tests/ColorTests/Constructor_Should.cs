using NUnit.Framework;

namespace OnlineShop.Libs.Models.Tests.ColorTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void NotSet_Name()
        {
            var obj = new Color();

            Assert.AreEqual(null, obj.Name);
        }

        [Test]
        public void NotSet_HexCode()
        {
            var obj = new Color();

            Assert.AreEqual(null, obj.HexColor);
        }
    }
}
