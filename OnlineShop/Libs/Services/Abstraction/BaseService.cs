using Bytes2you.Validation;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data.Factories;
using OnlineShop.Libs.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Services.Abstraction
{
    public abstract class BaseService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        protected BaseService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            Guard.WhenArgument(unitOfWorkFactory, "unitOfWorkFactory").IsNull().Throw();

            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        protected IUnitOfWorkFactory UnitOfWorkFactory
        {
            get
            {
                return this.unitOfWorkFactory;
            }
        }

        protected virtual T GetById<T>(IRepository<T> repo, Guid id)
                                            where T : IDbModel
        {
            return repo.GetById(id);
        }

        protected virtual T Add<T>(IRepository<T> repo, T item) where T : IDbModel
        {
            if (!this.IsValid(item))
            {
                throw new ArgumentException("Invalid item for add!");
            }

            using (var unitOfWork = this.unitOfWorkFactory.GetUnitOfWork())
            {
                repo.Add(item);
                unitOfWork.SaveChanges();
            }

            return this.GetById(repo, item.Id);
        }

        protected virtual T Update<T>(IRepository<T> repo, T item) where T : IDbModel
        {
            if (!this.IsValid(item))
            {
                throw new ArgumentException("Invalid item for update!");
            }

            using (var unitOfWork = this.unitOfWorkFactory.GetUnitOfWork())
            {
                repo.Update(item);
                unitOfWork.SaveChanges();
            }

            return this.GetById(repo, item.Id);
        }

        protected virtual void Hide<T>(IRepository<T> repo, T item) where T : IDbModel
        {
            if (!this.IsValid(item))
            {
                throw new ArgumentException("Invalid item for hide!");
            }

            using (var unitOfWork = this.unitOfWorkFactory.GetUnitOfWork())
            {
                item.IsDeleted = true;
                repo.Update(item);
                unitOfWork.SaveChanges();
            }
        }

        protected virtual void Delete<T>(IRepository<T> repo, T item) where T : IDbModel
        {
            if (!this.IsValid(item))
            {
                throw new ArgumentException("Invalid item for delete!");
            }

            using (var unitOfWork = this.unitOfWorkFactory.GetUnitOfWork())
            {
                repo.Delete(item);
                unitOfWork.SaveChanges();
            }
        }

        protected virtual IEnumerable<T> GetAll<T>(IRepository<T> repo) where T : IDbModel
        {
            return repo.GetAll();
        }

        protected virtual IEnumerable<T> GetAll<T>(IRepository<T> repo,
                                                    Expression<Func<T, bool>> filter)
                                                        where T : IDbModel
        {
            return repo.GetAll(filter);
        }

        protected virtual IEnumerable<T> GetAll<T, T1>(IRepository<T> repo,
                                                    Expression<Func<T, bool>> filter,
                                                    Expression<Func<T, T1>> orderBy)
                                                        where T : IDbModel
        {
            return repo.GetAll(filter, orderBy);
        }

        protected virtual IEnumerable<TResult> GetAll<T, T1, TResult>(IRepository<T> repo,
                                            Expression<Func<T, bool>> filter,
                                            Expression<Func<T, T1>> orderBy,
                                            Expression<Func<T, TResult>> select)
                                                where T : IDbModel
        {
            return repo.GetAll(filter, orderBy, select);
        }

        protected virtual IEnumerable<T> GetAll<T>(IRepository<T> repo,
                                        Expression<Func<T, bool>> filter,
                                        int page,
                                        int pageSize)
                                            where T : IDbModel
        {
            return repo.GetAll(filter, page, pageSize);
        }

        protected virtual IEnumerable<T> GetAll<T, T1>(IRepository<T> repo,
                                        Expression<Func<T, bool>> filter,
                                        Expression<Func<T, T1>> orderBy,
                                        int page,
                                        int pageSize)
                                            where T : IDbModel
        {
            return repo.GetAll(filter, orderBy, page, pageSize);
        }

        protected virtual IEnumerable<TResult> GetAll<T, T1, TResult>(IRepository<T> repo,
                                            Expression<Func<T, bool>> filter,
                                            Expression<Func<T, T1>> orderBy,
                                            Expression<Func<T, TResult>> select,
                                            int page,
                                            int pageSize)
                                                where T : IDbModel
        {
            return repo.GetAll(filter, orderBy, select, page, pageSize);
        }

        protected virtual IEnumerable<T> GetDeleted<T>(IRepository<T> repo)
                                                            where T : IDbModel
        {
            return this.GetAll(repo, (x) => x.IsDeleted);
        }

        protected virtual bool IsValid<T>(T item) 
                                where T : IDbModel
        {
            return !(item == null);
        }
    }
}