using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data.Tests.Mocks;
using System.Data.Entity;

namespace OnlineShop.Libs.Data.Tests.EfQuerableTasts
{
    [TestFixture]
    public class FindByKey_Should
    {
        [TestCase(new object[] { 5, "randomsString" })]
        [TestCase(new object[] { 0, "", 0, 8, "3cdcdsacda", "randomsString" })]
        [TestCase(new object[] { "weqcewqc", 82, null, 5, "randomsString" })]
        [TestCase(new object[] { 0 })]

        public void CallOnce_DbSet_Find_WithSameArguments(object[] randomParams)
        {
            object[] actualParams = null;

            // Arange

            var mockedDbSet = new Mock<IDbSet<DimmyClass>>();
            mockedDbSet.Setup(x => x.Find(It.IsAny<object[]>())).Callback((object[] x) => actualParams = x);

            var mockedDbContext = new Mock<IEfOnlineShopDbContext>();
            mockedDbContext.Setup(x => x.GetSet<DimmyClass>()).Returns(mockedDbSet.Object);

            var obj = new EfQuerable<DimmyClass>(mockedDbContext.Object);

            // Act 
            obj.FindByKey(randomParams);

            // Assert
            CollectionAssert.AreEquivalent(randomParams, actualParams);
        }
    }
}
