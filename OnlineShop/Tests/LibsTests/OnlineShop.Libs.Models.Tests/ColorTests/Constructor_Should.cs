using NUnit.Framework;

namespace OnlineShop.Libs.Models.Tests.ColorTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Parameterless_Constructor_Should_Exsist()
        {
            var obj = new Color();

            Assert.IsInstanceOf<Color>(obj);
        }

        [Test]
        public void NotSet_Id()
        {
            var obj = new Color();

            Assert.AreEqual(0, obj.Id);
        }

        [Test]
        public void NotSet_IsDeleted()
        {
            var obj = new Color();

            Assert.AreEqual(false, obj.IsDeleted);
        }

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
