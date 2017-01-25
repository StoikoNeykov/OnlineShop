using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OnlineShop.Libs.Models.Tests.ColorTests
{
    [TestFixture]
    public class Id_Should
    {
        [Test]
        public void Have_Key_Attribute()
        {
            var propertyName = "Id";

            var result = typeof(Color)
                            .GetProperty(propertyName)
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(KeyAttribute))
                            .SingleOrDefault();

            Assert.IsNotNull(result);
        }

        [TestCase(0)]
        [TestCase(-300)]
        [TestCase(3444214)]
        public void GetAndSet_Should_Work(int randomNumber)
        {
            var obj = new Color();

            obj.Id = randomNumber;

            Assert.AreEqual(randomNumber, obj.Id);
        }
    }
}
