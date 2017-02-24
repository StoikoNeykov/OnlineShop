﻿using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data.Tests.Mocks;
using System.Data.Entity;

namespace OnlineShop.Libs.Data.Tests.RepositoryTests
{
    [TestFixture]
    public class Update_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_WhenEntity_IsNull()
        {
            // Arange
            var mockedSet = new Mock<IDbSet<DimmyClass>>();
            var mockedStateful = new Mock<IStateful<DimmyClass>>();

            var mockedContext = new Mock<IOnlineShopDbContext>();
            mockedContext.Setup(x => x.Set<DimmyClass>()).Returns(mockedSet.Object);
            mockedContext.Setup(x => x.GetStateful<DimmyClass>(It.IsAny<DimmyClass>())).Returns(mockedStateful.Object);

            var obj = new Repository<DimmyClass>(mockedContext.Object);

            // Act & Assert
            Assert.That(() => obj.Update(null),
                                   Throws.ArgumentNullException.With.Message.Contains("entity"));
        }

        [Test]
        public void Change_StatefulState_ToModified()
        {
            // Arange
            var mockedSet = new Mock<IDbSet<DimmyClass>>();

            var mockedStateful = new Mock<IStateful<DimmyClass>>();
            mockedStateful.SetupSet(x => x.State = EntityState.Modified).Verifiable();

            var mockedContext = new Mock<IOnlineShopDbContext>();
            mockedContext.Setup(x => x.Set<DimmyClass>()).Returns(mockedSet.Object);
            mockedContext.Setup(x => x.GetStateful<DimmyClass>(It.IsAny<DimmyClass>())).Returns(mockedStateful.Object);

            var obj = new Repository<DimmyClass>(mockedContext.Object);

            // Act
            obj.Update(new DimmyClass());

            // Assert
            mockedStateful.Verify();
        }
    }
}
