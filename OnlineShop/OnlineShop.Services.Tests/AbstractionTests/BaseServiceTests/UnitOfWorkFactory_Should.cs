using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Factories;
using OnlineShop.Services.Tests.AbstractionTests.BaseServiceTests.Mock;

namespace OnlineShop.Services.Tests.AbstractionTests.BaseServiceTests
{
    [TestFixture]
    public class UnitOfWorkFactory_Should
    {
        [Test]
        public void Return_SameFactory_PassedInConstructor()
        {
            // Arange
            var mockedFactory = new Mock<IUnitOfWorkFactory>();

            // Act 
            var obj = new ServiceChildWithSpecificIsValidMethod(mockedFactory.Object, _ => true);

            // Assert
            Assert.AreSame(mockedFactory.Object, obj.UnitOfWorkFactory);
        }
    }
}
