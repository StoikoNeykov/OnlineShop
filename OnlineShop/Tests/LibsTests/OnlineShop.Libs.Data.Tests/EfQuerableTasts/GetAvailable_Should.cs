using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data.Tests.Helpers;
using OnlineShop.Libs.Data.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace OnlineShop.Libs.Data.Tests.EfQuerableTasts
{
    [TestFixture]
    public class GetAvailable_Should
    {
        [Test]
        public void Return_QuerableFilteredBy_IsDeleted()
        {
            var mockedCollection = DimmyClass.GetDimmyCollection();

            Expression<Func<DimmyClass, bool>> expectedExpression = x => x.IsDeleted == false;
            IEnumerable<DimmyClass> expectedResult = mockedCollection.Where(expectedExpression.Compile()).ToList();

            // Arange
            var mockedDbSet = QueryableDbSetMock.GetQueryableMockDbSet(mockedCollection);

            var mockedEntryProvider = new Mock<IEfEntryProvider>();

            var obj = new EfQuerable<DimmyClass>(mockedDbSet, mockedEntryProvider.Object);

            // Act 
            var result = obj.GetAvailabe;

            // Assert
            CollectionAssert.AreEquivalent(expectedResult, result.ToList());
        }
    }
}
