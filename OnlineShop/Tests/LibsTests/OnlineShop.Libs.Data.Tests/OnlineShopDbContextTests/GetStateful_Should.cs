using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Factories;
using OnlineShop.Libs.Models;
using OnlineShop.Libs.Models.Contracts;
using System.Data.Entity.Infrastructure;

namespace OnlineShop.Libs.Data.Tests.OnlineShopDbContextTests
{
    [TestFixture]
    public class GetStateful_Should
    {
        [Test]
        public void Call_StatefulFactory_Method_Once()
        {
            var mockedFactory = new Mock<IStatefulFactory>();
            mockedFactory.Setup(x => x.GetStateful(It.IsAny<DbEntityEntry<Color>>()));

            var model = new Color();

            var obj = new MockedDbContext("any", mockedFactory.Object);
            obj.GetStateful(model);

            mockedFactory.Verify(x => x.GetStateful(It.IsAny<DbEntityEntry<Color>>()), Times.Once);
        }

        [Test]
        public void Call_StatefulFactory_Method_Once_DifferentModel()
        {
            var mockedFactory = new Mock<IStatefulFactory>();
            mockedFactory.Setup(x => x.GetStateful(It.IsAny<DbEntityEntry<Category>>()));

            var model = new Category();

            var obj = new MockedDbContext("any", mockedFactory.Object);
            obj.GetStateful(model);

            mockedFactory.Verify(x => x.GetStateful(It.IsAny<DbEntityEntry<Category>>()), Times.Once);
        }

        [Test]
        public void Call_BaseEntryMethod_And_ThrowInvalidOperationException_WhenCalledWith_ObjectOfNotRegisteredType()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var mockedModel = new SomeRandomClass();

            var obj = new OnlineShopDbContext("any", mockedFactory.Object);

            Assert.That(() => obj.GetStateful(mockedModel),
                        Throws.InvalidOperationException.With.Message.Contain("not part of the model for the current context"));
        }

        [Test]
        public void Call_BaseEntryMethod_And_ThrowInvalidOperationException_WhenCalledWith_ObjectOfNotRegisteredType_2ndTry()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var mockedModel = new Mock<IDbModel>();

            var obj = new OnlineShopDbContext("any", mockedFactory.Object);

            Assert.That(() => obj.GetStateful(mockedModel),
                        Throws.InvalidOperationException.With.Message.Contain("not part of the model for the current context"));
        }

        private class MockedDbContext : OnlineShopDbContext
        {
            public MockedDbContext(string connectionString, IStatefulFactory statefulFactory)
                : base(connectionString, statefulFactory)
            {
            }

            public new DbEntityEntry<T> Entry<T>(T entity) where T : class
            {
                var mock = new Mock<DbEntityEntry<T>>();

                return mock.Object;
            }
        }

        private class SomeRandomClass
        {

        }
    }
}
