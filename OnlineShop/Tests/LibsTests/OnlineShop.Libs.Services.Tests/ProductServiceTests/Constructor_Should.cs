using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Models;

namespace OnlineShop.Libs.Services.Tests.ProductServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_When_DataProvider_IsNull()
        {
            // Arange, Act, Assert
            Assert.That(() => new ProductService(null),
                            Throws.ArgumentNullException.With.Message.Contains("dataProvider"));
        }
    }
}
