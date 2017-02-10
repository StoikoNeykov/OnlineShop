using Moq;
using NUnit.Framework;
using OnlineShop.ConfigurationProviders;
using OnlineShop.Libs.Data.Factories;
using OnlineShop.Libs.Data.Tests.Mocks;
using OnlineShop.Libs.Models;
using OnlineShop.Libs.Models.Contracts;
using System.Data.Entity.Infrastructure;

namespace OnlineShop.Libs.Data.Tests.OnlineShopDbContextTests
{
    [TestFixture]
    public class GetStateful_Should
    {
        private string validConnectionString = new ConnectionStringProvider(new EnvoirmentProvider()).ConnectionString;
        
        [Test]
        public void Call_StatefulFactory_Method_Once()
        {
            var mockedFactory = new Mock<IStatefulFactory>();
            mockedFactory.Setup(x => x.GetStateful(It.IsAny<DbEntityEntry<Category>>()));

            var model = new Category();

            var obj = new MockedDbContext(this.validConnectionString, mockedFactory.Object);
            obj.GetStateful(model);

            mockedFactory.Verify(x => x.GetStateful(It.IsAny<DbEntityEntry<Category>>()), Times.Once);
        }

        [Test]
        public void Call_StatefulFactory_Method_Once_DifferentModel()
        {
            var mockedFactory = new Mock<IStatefulFactory>();
            mockedFactory.Setup(x => x.GetStateful(It.IsAny<DbEntityEntry<Category>>()));

            var model = new Category();

            var obj = new MockedDbContext(this.validConnectionString, mockedFactory.Object);
            obj.GetStateful(model);

            mockedFactory.Verify(x => x.GetStateful(It.IsAny<DbEntityEntry<Category>>()), Times.Once);
        }

        [Test]
        public void Call_BaseEntryMethod_And_ThrowInvalidOperationException_WhenCalledWith_ObjectOfNotRegisteredType()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var mockedModel = new DimmyClass();

            var obj = new OnlineShopDbContext(this.validConnectionString, mockedFactory.Object);

            Assert.That(() => obj.GetStateful(mockedModel),
                        Throws.InvalidOperationException.With.Message.Contain("not part of the model for the current context"));
        }

        [Test]
        public void Call_BaseEntryMethod_And_ThrowInvalidOperationException_WhenCalledWith_ObjectOfNotRegisteredType_2ndTry()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var mockedModel = new Mock<IDbModel>();

            var obj = new OnlineShopDbContext(this.validConnectionString, mockedFactory.Object);

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
    }
}
