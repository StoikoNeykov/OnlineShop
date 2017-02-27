using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data.Factories;
using OnlineShop.Libs.Models.Contracts;
using OnlineShop.Services.Abstraction;
using OnlineShop.Libs.Services.Tests.AbstractionTests.BaseServiceTests.Mock;
using System;

namespace OnlineShop.Libs.Services.Tests.AbstractionTests.BaseServiceTests
{
    [TestFixture]
    public class Add_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_WhenRepoArgument_IsNull()
        {
            // Arange
            var mockedFactory = new Mock<IUnitOfWorkFactory>();
            var mockedItem = new Mock<IDbModel>();

            Func<IDbModel, bool> func = x => true;

            var obj = new ServiceChildWithSpecificIsValidMethod(mockedFactory.Object, func);

            // Act & Assert
            Assert.That(() => obj.Add(null, mockedItem.Object),
                    Throws.ArgumentNullException.With.Message.Contains("repo"));
        }

        [Test]
        public void Call_OwnMethod_IsValid_ToValidate_ItemArgument_IfRepoArgumentIsValid()
        {
            // Arange
            var randomGuid = Guid.NewGuid();

            var mockedItem = new Mock<IDbModel>();
            mockedItem.Setup(x => x.Id).Returns(randomGuid);

            var specificBehavior = new Mock<Func<IDbModel, bool>>();
            specificBehavior.Setup(x => x(mockedItem.Object)).Returns(true).Verifiable();

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            // setup to not throw
            mockedUnitOfWork.Setup(x => x.SaveChanges());
            mockedUnitOfWork.Setup(x => x.Dispose());

            var mockedFactory = new Mock<IUnitOfWorkFactory>();
            mockedFactory.Setup(x => x.GetUnitOfWork()).Returns(mockedUnitOfWork.Object);

            var mockedRepo = new Mock<IRepository<IDbModel>>();
            // setup to not throw
            mockedRepo.Setup(x => x.Add(mockedItem.Object));

            var obj = new ServiceChildWithSpecificIsValidMethod(mockedFactory.Object, specificBehavior.Object);

            // Act
            obj.Add(mockedRepo.Object, mockedItem.Object);

            // Assert
            specificBehavior.Verify();
        }

        [Test]
        public void Throw_ArgumentException_WithProperMessage_WhenIsValid_ReturnFalse()
        {
            // Arange
            var randomGuid = Guid.NewGuid();

            var mockedItem = new Mock<IDbModel>();
            mockedItem.Setup(x => x.Id).Returns(randomGuid);

            var specificBehavior = new Mock<Func<IDbModel, bool>>();
            specificBehavior.Setup(x => x(mockedItem.Object)).Returns(false);

            var mockedFactory = new Mock<IUnitOfWorkFactory>();

            var mockedRepo = new Mock<IRepository<IDbModel>>();

            var obj = new ServiceChildWithSpecificIsValidMethod(mockedFactory.Object, specificBehavior.Object);

            // Act & Assert
            Assert.That(() => obj.Add(mockedRepo.Object, mockedItem.Object),
                                        Throws.ArgumentException.With.Message.SameAs(BaseService.InvalidItemForAddErrorMessage));
        }

        [Test]
        public void Call_RepoAddMethod_WhenArguments_AreValid()
        {
            // Arange
            var randomGuid = Guid.NewGuid();

            var mockedItem = new Mock<IDbModel>();
            mockedItem.Setup(x => x.Id).Returns(randomGuid);

            var specificBehavior = new Mock<Func<IDbModel, bool>>();
            specificBehavior.Setup(x => x(mockedItem.Object)).Returns(true);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            // setup to not throw
            mockedUnitOfWork.Setup(x => x.SaveChanges());
            mockedUnitOfWork.Setup(x => x.Dispose());

            var mockedFactory = new Mock<IUnitOfWorkFactory>();
            mockedFactory.Setup(x => x.GetUnitOfWork()).Returns(mockedUnitOfWork.Object);

            var mockedRepo = new Mock<IRepository<IDbModel>>();
            // setup to not throw
            mockedRepo.Setup(x => x.Add(mockedItem.Object)).Verifiable();

            var obj = new ServiceChildWithSpecificIsValidMethod(mockedFactory.Object, specificBehavior.Object);

            // Act
            obj.Add(mockedRepo.Object, mockedItem.Object);

            // Assert
            mockedRepo.Verify();
        }

        [Test]
        public void Call_UnitOfWorkSaveChanges_WhenArguments_AreValid()
        {
            // Arange
            var randomGuid = Guid.NewGuid();

            var mockedItem = new Mock<IDbModel>();
            mockedItem.Setup(x => x.Id).Returns(randomGuid);

            var specificBehavior = new Mock<Func<IDbModel, bool>>();
            specificBehavior.Setup(x => x(mockedItem.Object)).Returns(true);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            // setup to not throw
            mockedUnitOfWork.Setup(x => x.SaveChanges()).Verifiable();
            mockedUnitOfWork.Setup(x => x.Dispose());

            var mockedFactory = new Mock<IUnitOfWorkFactory>();
            mockedFactory.Setup(x => x.GetUnitOfWork()).Returns(mockedUnitOfWork.Object);

            var mockedRepo = new Mock<IRepository<IDbModel>>();
            // setup to not throw
            mockedRepo.Setup(x => x.Add(mockedItem.Object));

            var obj = new ServiceChildWithSpecificIsValidMethod(mockedFactory.Object, specificBehavior.Object);

            // Act
            obj.Add(mockedRepo.Object, mockedItem.Object);

            // Assert
            mockedUnitOfWork.Verify();
        }

        [Test]
        public void Call_UnitOfWorkDispose_WhenArguments_AreValid()
        {
            // Arange
            var randomGuid = Guid.NewGuid();

            var mockedItem = new Mock<IDbModel>();
            mockedItem.Setup(x => x.Id).Returns(randomGuid);

            var specificBehavior = new Mock<Func<IDbModel, bool>>();
            specificBehavior.Setup(x => x(mockedItem.Object)).Returns(true);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            // setup to not throw
            mockedUnitOfWork.Setup(x => x.SaveChanges());
            mockedUnitOfWork.Setup(x => x.Dispose()).Verifiable();

            var mockedFactory = new Mock<IUnitOfWorkFactory>();
            mockedFactory.Setup(x => x.GetUnitOfWork()).Returns(mockedUnitOfWork.Object);

            var mockedRepo = new Mock<IRepository<IDbModel>>();
            // setup to not throw
            mockedRepo.Setup(x => x.Add(mockedItem.Object));

            var obj = new ServiceChildWithSpecificIsValidMethod(mockedFactory.Object, specificBehavior.Object);

            // Act
            obj.Add(mockedRepo.Object, mockedItem.Object);

            // Assert
            mockedUnitOfWork.Verify();
        }

        [Test]
        public void Call_StatementsInSpecificOrder_WhenArguments_AreValid()
        {
            var order = string.Empty;

            // Arange
            var randomGuid = Guid.NewGuid();

            var mockedItem = new Mock<IDbModel>();
            mockedItem.Setup(x => x.Id).Returns(randomGuid);

            var specificBehavior = new Mock<Func<IDbModel, bool>>();
            specificBehavior.Setup(x => x(mockedItem.Object)).Returns(true)
                                        .Callback(() => order += "0");

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            // setup to not throw
            mockedUnitOfWork.Setup(x => x.SaveChanges()).Callback(() => order += "2");
            mockedUnitOfWork.Setup(x => x.Dispose()).Callback(() => order += "3");

            var mockedFactory = new Mock<IUnitOfWorkFactory>();
            mockedFactory.Setup(x => x.GetUnitOfWork()).Returns(mockedUnitOfWork.Object)
                                                            .Callback(() => order += "1");

            var mockedRepo = new Mock<IRepository<IDbModel>>();
            // setup to not throw
            mockedRepo.Setup(x => x.Add(mockedItem.Object));

            var obj = new ServiceChildWithSpecificIsValidMethod(mockedFactory.Object, specificBehavior.Object);

            // Act
            obj.Add(mockedRepo.Object, mockedItem.Object);

            // Assert
            Assert.AreEqual("0123", order);
        }
    }
}
