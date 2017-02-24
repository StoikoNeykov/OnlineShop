using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data.Tests.Helpers;
using OnlineShop.Libs.Data.Tests.Mocks;
using System.Data.Entity;
using System.Linq;

namespace OnlineShop.Libs.Data.Tests.RepositoryTests
{
    [TestFixture]
    public class GetDeleted_Should
    {
        [Test]
        public void Return_DeletedMembers_FromSet_Only()
        {
            // Arange 
            var collection = DimmyClass.GetDimmyCollection();

            var expected = collection
                                .Where(x => x.IsDeleted)
                                .Select(x => x.Id)
                                .ToList();

            var mockedSetObject = QueryableDbSetMock.GetQueryableMockDbSet(collection);

            var mockedContext = new Mock<IOnlineShopDbContext>();
            mockedContext.Setup(x => x.Set<DimmyClass>()).Returns(mockedSetObject);

            var obj = new Repository<DimmyClass>(mockedContext.Object);

            // Act
            var actual = obj
                            .GetDeleted()
                            .Select(x => x.Id);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
