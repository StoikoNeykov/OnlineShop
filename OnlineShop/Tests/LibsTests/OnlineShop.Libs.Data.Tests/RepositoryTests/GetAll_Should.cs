using Moq;
using NUnit.Framework;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data.Tests.Helpers;
using OnlineShop.Libs.Data.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OnlineShop.Libs.Data.Tests.RepositoryTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void Return_All()
        {
            var collection = DimmyClass.GetDimmyCollection();

            var expected = collection
                                .Select(x => x.Id)
                                .ToList();

            var mockedSetObject = QueryableDbSetMock.GetQueryableMockDbSet(collection);

            var mockedContext = new Mock<IOnlineShopDbContext>();
            mockedContext.Setup(x => x.Set<DimmyClass>()).Returns(mockedSetObject);

            var obj = new Repository<DimmyClass>(mockedContext.Object);

            var actual = obj
                            .GetAll()
                            .Select(x => x.Id);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Return_Filtered_WhenHave_Filter()
        {
            Expression<Func<DimmyClass, bool>> filter = x => x.Id.ToString().Contains("2");

            var collection = DimmyClass.GetDimmyCollection();
            
            var expected = collection
                                .Where(filter.Compile())
                                .Select(x => x.Id)
                                .ToList();

            var mockedSetObject = QueryableDbSetMock.GetQueryableMockDbSet(collection);

            var mockedContext = new Mock<IOnlineShopDbContext>();
            mockedContext.Setup(x => x.Set<DimmyClass>()).Returns(mockedSetObject);

            var obj = new Repository<DimmyClass>(mockedContext.Object);

            var actual = obj
                            .GetAll(filter)
                            .Select(x => x.Id);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Return_FilteredAndPaged_WhenHave_FilterAndPaging()
        {
            Expression<Func<DimmyClass, bool>> filter = x => x.Id.ToString().Contains("a");
            var pagesize = 3;
            var page = 2;

            var collection = DimmyClass.GetDimmyCollection();

            var expected = collection
                                .Where(filter.Compile())
                                .Skip(pagesize * page)
                                .Take(pagesize)
                                .Select(x => x.Id)
                                .ToList();

            var mockedSetObject = QueryableDbSetMock.GetQueryableMockDbSet(collection);

            var mockedContext = new Mock<IOnlineShopDbContext>();
            mockedContext.Setup(x => x.Set<DimmyClass>()).Returns(mockedSetObject);

            var obj = new Repository<DimmyClass>(mockedContext.Object);

            var actual = obj
                            .GetAll(filter, page, pagesize)
                            .Select(x => x.Id);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Return_FilteredAndOrdered_WhenHave_FilterAndOrder()
        {
            Expression<Func<DimmyClass, bool>> filter = x => x.Id.ToString().Contains("h");
            Expression<Func<DimmyClass, Guid>> orderBy = x => x.Id;

            var collection = DimmyClass.GetDimmyCollection();

            var expected = collection
                                .Where(filter.Compile())
                                .OrderBy(orderBy.Compile())
                                .Select(x => x.Id)
                                .ToList();

            var mockedSetObject = QueryableDbSetMock.GetQueryableMockDbSet(collection);

            var mockedContext = new Mock<IOnlineShopDbContext>();
            mockedContext.Setup(x => x.Set<DimmyClass>()).Returns(mockedSetObject);

            var obj = new Repository<DimmyClass>(mockedContext.Object);

            var actual = obj
                            .GetAll(filter, orderBy)
                            .Select(x => x.Id);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Return_FilteredOrderedAndPaged_WhenHave_FilterOrderAndPaging()
        {
            Expression<Func<DimmyClass, bool>> filter = x => x.Id.ToString().Contains("z");
            Expression<Func<DimmyClass, Guid>> orderBy = x => x.Id;

            var pagesize = 3;
            var page = 2;

            var collection = DimmyClass.GetDimmyCollection();

            var expected = collection
                                .Where(filter.Compile())
                                .OrderBy(orderBy.Compile())
                                .Skip(pagesize * page)
                                .Take(pagesize)
                                .Select(x => x.Id)
                                .ToList();

            var mockedSetObject = QueryableDbSetMock.GetQueryableMockDbSet(collection);

            var mockedContext = new Mock<IOnlineShopDbContext>();
            mockedContext.Setup(x => x.Set<DimmyClass>()).Returns(mockedSetObject);

            var obj = new Repository<DimmyClass>(mockedContext.Object);

            var actual = obj
                            .GetAll(filter, orderBy, page, pagesize)
                            .Select(x => x.Id);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Return_FilteredOrderedAndSelected_WhenHave_FilterOrderAndSelect()
        {
            Expression<Func<DimmyClass, bool>> filter = x => x.Id.ToString().Contains("g");
            Expression<Func<DimmyClass, Guid>> orderBy = x => x.Id;
            Expression<Func<DimmyClass, Guid>> select = x => x.Id;

            var collection = DimmyClass.GetDimmyCollection();

            var expected = collection
                                .Where(filter.Compile())
                                .OrderBy(orderBy.Compile())
                                .Select(select.Compile())
                                .ToList();

            var mockedSetObject = QueryableDbSetMock.GetQueryableMockDbSet(collection);

            var mockedContext = new Mock<IOnlineShopDbContext>();
            mockedContext.Setup(x => x.Set<DimmyClass>()).Returns(mockedSetObject);

            var obj = new Repository<DimmyClass>(mockedContext.Object);

            var actual = obj
                            .GetAll(filter, orderBy, select);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Return_FilteredOrderedSelectedAndPaged_WhenHave_FilterOrderSelectAndPaging()
        {
            Expression<Func<DimmyClass, bool>> filter = x => x.Id.ToString().Contains("n");
            Expression<Func<DimmyClass, Guid>> orderBy = x => x.Id;
            Expression<Func<DimmyClass, Guid>> select = x => x.Id;

            var pagesize = 3;
            var page = 2;

            var collection = DimmyClass.GetDimmyCollection();

            var expected = collection
                                .Where(filter.Compile())
                                .OrderBy(orderBy.Compile())
                                .Skip(pagesize * page)
                                .Take(pagesize)
                                .Select(select.Compile())
                                .ToList();

            var mockedSetObject = QueryableDbSetMock.GetQueryableMockDbSet(collection);

            var mockedContext = new Mock<IOnlineShopDbContext>();
            mockedContext.Setup(x => x.Set<DimmyClass>()).Returns(mockedSetObject);

            var obj = new Repository<DimmyClass>(mockedContext.Object);

            var actual = obj
                            .GetAll(filter, orderBy, select, page, pagesize);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
