using NUnit.Framework;
using OnlineShop.Libs.DtoModels;
using OnlineShop.Libs.Models;
using OnlineShop.Libs.Services.Tests.Helpers;
using System.Linq;

namespace OnlineShop.Libs.Services.Tests.MapperServiceTests
{
    [TestFixture]
    public class Map_Should
    {
        [Test]
        public void Return_DtoProperly_WhenProductIsValid()
        {
            // Arange
            var product = ProductGenerator.GetProducts(1).First();

            var obj = new MapperService();

            // Act
            var result = obj.Map(product);

            // Assert
            Assert.AreEqual(product.ProductId, result.ProductId);
            Assert.AreEqual(product.Name, result.Name);
            Assert.AreEqual(product.Count, result.Count);
            Assert.AreEqual(product.Price, result.Price);
            Assert.AreEqual(product.Photo1, result.Photo1);
            Assert.AreEqual(product.Photo2, result.Photo2);
            Assert.AreEqual(product.Photo3, result.Photo3);
            Assert.AreEqual(product.Photo4, result.Photo4);
        }

        [Test]
        public void Return_ProductProperly_WhenDtoIsValid()
        {
            // Arange
            var product = ProductGenerator.GetProductDtos(1).First();

            var obj = new MapperService();

            // Act
            var result = obj.Map(product);

            // Assert
            Assert.AreEqual(product.ProductId, result.ProductId);
            Assert.AreEqual(product.Name, result.Name);
            Assert.AreEqual(product.Count, result.Count);
            Assert.AreEqual(product.Price, result.Price);
            Assert.AreEqual(product.Photo1, result.Photo1);
            Assert.AreEqual(product.Photo2, result.Photo2);
            Assert.AreEqual(product.Photo3, result.Photo3);
            Assert.AreEqual(product.Photo4, result.Photo4);
        }

        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_WhenProductIsNull()
        {
            // Arrange
            var obj = new MapperService();

            // Act, Assert
            Assert.That(() => obj.Map((Product)null),
                                    Throws.ArgumentNullException.With.Message.Contains("product"));
        }

        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_WhenProductDtoIsNull()
        {
            // Arrange
            var obj = new MapperService();

            // Act, Assert
            Assert.That(() => obj.Map((ProductDto)null),
                                    Throws.ArgumentNullException.With.Message.Contains("product"));
        }
    }
}
