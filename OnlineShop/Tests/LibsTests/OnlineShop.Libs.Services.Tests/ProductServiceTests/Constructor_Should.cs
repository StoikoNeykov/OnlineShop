using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Models;
using OnlineShop.Libs.Services.Contracts;

namespace OnlineShop.Libs.Services.Tests.ProductServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_When_IEfQuerable_IsNull()
        {
            // Arange
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();
            var mockedMapperService = new Mock<IMapperService>();
            
            // Act, Assert
            Assert.That(() => new ProductService(null, mockedUnitOfWork.Object, mockedMapperService.Object),
                            Throws.ArgumentNullException.With.Message.Contains("products"));
        }

        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_When_UnitOfWork_IsNull()
        {
            // Arange
            var mockedQuerable = new Mock<IEfQuerable<Product>>();
            var mockedMapperService = new Mock<IMapperService>();
            
            // Act, Assert
            Assert.That(() => new ProductService(mockedQuerable.Object, null, mockedMapperService.Object),
                            Throws.ArgumentNullException.With.Message.Contains("unitOfWork"));
        }

        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_When_MapperService_IsNull()
        {
            // Arange
            var mockedQuerable = new Mock<IEfQuerable<Product>>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();

            // Act, Assert
            Assert.That(() => new ProductService(mockedQuerable.Object, mockedUnitOfWork.Object, null),
                            Throws.ArgumentNullException.With.Message.Contains("mapperService"));
        }
    }
}
