using Moq;
using OnlineShop.Libs.Data;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Models.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Libs.Services.Tests.Helpers
{
    public static class QuerableMock
    {
        public static Mock<IEfQuerable<TEntity>> GetQuetableMock<TEntity>(IEnumerable<TEntity> sourse)
            where TEntity : class, IDbModel
        {
            var asQuerable = sourse.AsQueryable();

            var result = new Mock<IEfQuerable<TEntity>>();
            result.As<IQueryable<TEntity>>().Setup(x => x.Provider).Returns(asQuerable.Provider);
            result.As<IQueryable<TEntity>>().Setup(x => x.Expression).Returns(asQuerable.Expression);
            result.As<IQueryable<TEntity>>().Setup(x => x.ElementType).Returns(asQuerable.ElementType);
            result.As<IQueryable<TEntity>>().Setup(x => x.GetEnumerator()).Returns(asQuerable.GetEnumerator());

            return result;
        }
    }
}
