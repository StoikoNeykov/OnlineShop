using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data.Factories;
using OnlineShop.Libs.Models.Contracts;
using OnlineShop.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OnlineShop.Services.Tests.AbstractionTests.BaseServiceTests.Mock
{
    /// <summary>
    /// Expose parent members for testing
    /// </summary>
    public class ServiceChild : BaseService
    {
        public ServiceChild(IUnitOfWorkFactory unitOfWorkFactory)
            : base(unitOfWorkFactory)
        {
        }

        public IUnitOfWorkFactory UnitOfWorkFactory
        {
            get
            {
                return base.UnitOfWorkFactory;
            }
        }

        public T GetById<T>(IRepository<T> repo, Guid id)
                                            where T : IDbModel
        {
            return base.GetById(repo, id);
        }

        public T Add<T>(IRepository<T> repo, T item) where T : IDbModel
        {
            return base.Add(repo, item);
        }

        public T Update<T>(IRepository<T> repo, T item) where T : IDbModel
        {
            return base.Update(repo, item);
        }

        public void Hide<T>(IRepository<T> repo, T item) where T : IDbModel
        {
            base.Hide(repo, item);
        }

        public void Delete<T>(IRepository<T> repo, T item) where T : IDbModel
        {
            base.Delete(repo, item);
        }

        public IEnumerable<T> GetAll<T>(IRepository<T> repo) where T : IDbModel
        {
            return base.GetAll(repo);
        }

        public IEnumerable<T> GetAll<T>(IRepository<T> repo,
                                                    Expression<Func<T, bool>> filter)
                                                        where T : IDbModel
        {
            return base.GetAll(repo, filter);
        }

        public IEnumerable<T> GetAll<T, T1>(IRepository<T> repo,
                                                    Expression<Func<T, bool>> filter,
                                                    Expression<Func<T, T1>> orderBy)
                                                        where T : IDbModel
        {
            return base.GetAll(repo, filter, orderBy);
        }

        public IEnumerable<TResult> GetAll<T, T1, TResult>(IRepository<T> repo,
                                            Expression<Func<T, bool>> filter,
                                            Expression<Func<T, T1>> orderBy,
                                            Expression<Func<T, TResult>> select)
                                                where T : IDbModel
        {
            return base.GetAll(repo, filter, orderBy, select);
        }

        public IEnumerable<T> GetAll<T>(IRepository<T> repo,
                                        Expression<Func<T, bool>> filter,
                                        int page,
                                        int pageSize)
                                            where T : IDbModel
        {
            return base.GetAll(repo, filter, page, pageSize);
        }

        public IEnumerable<T> GetAll<T, T1>(IRepository<T> repo,
                                        Expression<Func<T, bool>> filter,
                                        Expression<Func<T, T1>> orderBy,
                                        int page,
                                        int pageSize)
                                            where T : IDbModel
        {
            return base.GetAll(repo, filter, orderBy, page, pageSize);
        }

        public IEnumerable<TResult> GetAll<T, T1, TResult>(IRepository<T> repo,
                                            Expression<Func<T, bool>> filter,
                                            Expression<Func<T, T1>> orderBy,
                                            Expression<Func<T, TResult>> select,
                                            int page,
                                            int pageSize)
                                                where T : IDbModel
        {
            return base.GetAll(repo, filter, orderBy, select, page, pageSize);
        }

        public IEnumerable<T> GetDeleted<T>(IRepository<T> repo)
                                                            where T : IDbModel
        {
            return base.GetDeleted(repo);
        }

        public bool IsValid<T>(T item)
                                where T : IDbModel
        {
            return base.IsValid(item);
        }
    }
}
