using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data.Factories;
using OnlineShop.Libs.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Services.Abstraction
{
    public class BaseService<T>
        where T : IDbModel
    {
        private IRepository<T> repo;
        private IUnitOfWorkFactory unitOfWorkFactory;

        public BaseService(IRepository<T> repo, IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.Repo = repo;
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        protected IRepository<T> Repo
        {
            get
            {
                return this.repo;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Repository");
                }

                this.repo = value;
            }
        }

        protected IUnitOfWorkFactory UnitOfWorkFactory
        {
            get
            {
                return this.unitOfWorkFactory;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("UnitOfWork");
                }

                this.unitOfWorkFactory = value;
            }
        }

        public virtual T GetById(Guid id)
        {
            return this.repo.GetById(id);
        }

        public virtual T Add(T item)
        {
            if (!this.IsValid(item))
            {
                throw new ArgumentException("Invalid item for add!");
            }

            using (var unitOfWork = this.unitOfWorkFactory.GetUnitOfWork())
            {
                this.repo.Add(item);
                unitOfWork.SaveChanges();
            }

            return this.GetById(item.Id);
        }

        public virtual T Update(T item)
        {
            if (!this.IsValid(item))
            {
                throw new ArgumentException("Invalid item for update!");
            }

            using (var unitOfWork = this.unitOfWorkFactory.GetUnitOfWork())
            {
                this.repo.Update(item);
                unitOfWork.SaveChanges();
            }

            return this.GetById(item.Id);
        }

        public virtual void Hide(T item)
        {
            if (!this.IsValid(item))
            {
                throw new ArgumentException("Invalid item for hide!");
            }

            using (var unitOfWork = this.unitOfWorkFactory.GetUnitOfWork())
            {
                item.IsDeleted = true;
                this.repo.Update(item);
                unitOfWork.SaveChanges();
            }
        }

        public virtual void Delete(T item)
        {
            if (!this.IsValid(item))
            {
                throw new ArgumentException("Invalid item for delete!");
            }

            using (var unitOfWork = this.unitOfWorkFactory.GetUnitOfWork())
            {
                this.repo.Delete(item);
                unitOfWork.SaveChanges();
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.repo.GetAll();
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return this.repo.GetAll(filter);
        }

        public virtual IEnumerable<T> GetAll<T1>(Expression<Func<T, bool>> filter,
                                                    Expression<Func<T, T1>> orderBy)
        {
            return this.repo.GetAll(filter, orderBy);
        }

        public virtual IEnumerable<TResult> GetAll<T1, TResult>(Expression<Func<T, bool>> filter,
                                            Expression<Func<T, T1>> orderBy,
                                            Expression<Func<T, TResult>> select)
        {
            return this.repo.GetAll(filter, orderBy, select);
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> filter,
                                        int page,
                                        int pageSize)
        {
            return this.repo.GetAll(filter, page, pageSize);
        }

        public virtual IEnumerable<T> GetAll<T1>(Expression<Func<T, bool>> filter,
                                        Expression<Func<T, T1>> orderBy,
                                        int page,
                                        int pageSize)
        {
            return this.repo.GetAll(filter, orderBy, page, pageSize);
        }

        public virtual IEnumerable<TResult> GetAll<T1, TResult>(Expression<Func<T, bool>> filter,
                                            Expression<Func<T, T1>> orderBy,
                                            Expression<Func<T, TResult>> select,
                                            int page,
                                            int pageSize)
        {
            return this.repo.GetAll(filter, orderBy, select, page, pageSize);
        }

        public virtual IEnumerable<T> GetDeleted()
        {
            return this.GetAll((x) => x.IsDeleted);
        }

        protected virtual bool IsValid(T item)
        {
            return !(item == null);
        }
    }
}