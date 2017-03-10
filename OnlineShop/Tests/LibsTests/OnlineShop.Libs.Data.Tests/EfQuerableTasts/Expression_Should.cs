using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data.Tests.Mocks;
using System;
using System.Data.Entity;
using System.Linq.Expressions;

namespace OnlineShop.Libs.Data.Tests.EfQuerableTasts
{
    [TestFixture]
    public class Expression_Should
    {
        [Test]
        public void Return_DbSet_Expression_Without_ChangeIt()
        {
            // Arange
            var mockedExpression = new Mock<Expression>();

            var mockedDbSet = new Mock<IDbSet<DimmyClass>>();
            mockedDbSet.Setup(x => x.Expression).Returns(mockedExpression.Object);

            var mockedEntryProvider = new Mock<IEfEntryProvider>();

            var obj = new EfQuerable<DimmyClass>(mockedDbSet.Object, mockedEntryProvider.Object);

            // Act
            var result = obj.Expression;

            // Assert
            Assert.AreSame(mockedExpression.Object, result);
        }
    }
}
