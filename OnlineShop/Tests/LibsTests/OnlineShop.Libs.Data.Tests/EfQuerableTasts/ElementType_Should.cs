﻿using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data.Tests.Mocks;
using System;
using System.Data.Entity;

namespace OnlineShop.Libs.Data.Tests.EfQuerableTasts
{
    [TestFixture]
    public class ElementType_Should
    {
        [Test]
        public void Return_DbSet_ElementType_Without_ChangeIt()
        {
            // Arange
            var mockedType = new Mock<Type>();

            var mockedDbSet = new Mock<IDbSet<DimmyClass>>();
            mockedDbSet.Setup(x => x.ElementType).Returns(mockedType.Object);

            var mockedEntryProvider = new Mock<IEfEntryProvider>();

            var obj = new EfQuerable<DimmyClass>(mockedDbSet.Object, mockedEntryProvider.Object);

            // Act
            var result = obj.ElementType;

            // Assert
            Assert.AreSame(mockedType.Object, result);
        }
    }
}
