using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data.Factories;
using OnlineShop.Libs.Models.Contracts;
using OnlineShop.Services.Tests.AbstractionTests.BaseServiceTests.Mock;
using System;

namespace OnlineShop.Services.Tests.AbstractionTests.BaseServiceTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_WhenRepoArgument_IsNull()
        {
            // Arange
            var mockedFactory = new Mock<IUnitOfWorkFactory>();

            var obj = new ServiceChild(mockedFactory.Object);

            Guid randomId = Guid.NewGuid();

            // Act & Assert
            Assert.That(() => obj.GetById<IDbModel>(null, randomId),
                                Throws.ArgumentNullException.With.Message.Contains("repo"));
        }


        [Test]
        public void Throw_ArgumentException_WithProperMessage_WhenId_IsGuidEmpty()
        {
            // Arange
            var mockedFactory = new Mock<IUnitOfWorkFactory>();
            var mockedRepo = new Mock<IRepository<IDbModel>>();

            var obj = new ServiceChild(mockedFactory.Object);

            // Act & Assert
            Assert.That(() => obj.GetById(mockedRepo.Object, Guid.Empty),
                                Throws.ArgumentException.With.Message.Contains("Guid.Empty"));
        }

        [Test]
        public void CallRepositoryGetById_WithSameId_OnlyOnce_WhenArguments_AreValid()
        {
            // Arange
            var mockedFactory = new Mock<IUnitOfWorkFactory>();
            Guid randomId = Guid.NewGuid();
            
            var mockedRepo = new Mock<IRepository<IDbModel>>();
            
            var obj = new ServiceChild(mockedFactory.Object);

            // Act
            obj.GetById(mockedRepo.Object, randomId);

            // Assert
            mockedRepo.Verify(x => x.GetById(randomId), Times.Once);
        }
    }
}
