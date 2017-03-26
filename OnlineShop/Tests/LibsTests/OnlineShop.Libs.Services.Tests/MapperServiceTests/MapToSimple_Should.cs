using NUnit.Framework;
using OnlineShop.Libs.Services.Tests.Helpers;
using System.Linq;

namespace OnlineShop.Libs.Services.Tests.MapperServiceTests
{
    [TestFixture]
    public class MapToSimple_Should
    {
        [Test]
        public void Return_ResultProperly_WhenArgumentIsValid()
        {
            // Arange
            var product = ProductGenerator.GetProducts(1).First();
            var obj = new MapperService();

            // Act
            var result = obj.MapToSimple(product);

            // Assert
            Assert.AreEqual(product.ProductId, result.Id);
            Assert.AreEqual(product.Name, result.Name);
            Assert.AreEqual(product.Price, result.Price);
            Assert.AreEqual(product.Photo1, result.ImageUrl);
            Assert.AreEqual(@"/" + product.Name, result.Link);
        }

        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_WhenArgument_IsNull()
        {
            // Arange
            var obj = new MapperService();

            // Act & Assert
            Assert.That(() => obj.MapToSimple(null),
                            Throws.ArgumentNullException.With.Message.Contains("product"));
        }
    }
}
