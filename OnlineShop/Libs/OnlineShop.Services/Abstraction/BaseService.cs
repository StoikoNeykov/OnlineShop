using Bytes2you.Validation;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data.Factories;
using OnlineShop.Libs.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OnlineShop.Services.Abstraction
{
    public abstract class BaseService
    {
        public const string InvalidItemForAddErrorMessage = "Invalid item for add!";
        public const string InvalidItemForUpdateErrorMessage = "Invalid item for update!";
        public const string InvalidItemForHideErrorMessage = "Invalid item for hide!";
        public const string InvalidItemForDeleteErrorMessage = "Invalid item for delete!";

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

        protected virtual void Add<T>(IRepository<T> repo, T item) where T : IDbModel
        {
            Guard.WhenArgument(repo, "repo").IsNull().Throw();

            if (!this.IsValid(item))
            {
                throw new ArgumentException(InvalidItemForAddErrorMessage);
            }

            using (var unitOfWork = this.unitOfWorkFactory.GetUnitOfWork())
            {
                repo.Add(item);
                unitOfWork.SaveChanges();
            }
        }

        protected virtual void Update<T>(IRepository<T> repo, T item) where T : IDbModel
        {
            Guard.WhenArgument(repo, "repo").IsNull().Throw();

            if (!this.IsValid(item))
            {
                throw new ArgumentException(InvalidItemForUpdateErrorMessage);
            }

            using (var unitOfWork = this.unitOfWorkFactory.GetUnitOfWork())
            {
                repo.Update(item);
                unitOfWork.SaveChanges();
            }
        }

        protected virtual void Hide<T>(IRepository<T> repo, T item) where T : IDbModel
        {
            Guard.WhenArgument(repo, "repo").IsNull().Throw();

            if (!this.IsValid(item))
            {
                throw new ArgumentException(InvalidItemForHideErrorMessage);
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
            Guard.WhenArgument(repo, "repo").IsNull().Throw();

            if (!this.IsValid(item))
            {
                throw new ArgumentException(InvalidItemForDeleteErrorMessage);
            }

            using (var unitOfWork = this.unitOfWorkFactory.GetUnitOfWork())
            {
                repo.Delete(item);
                unitOfWork.SaveChanges();
            }
        }

        protected virtual IEnumerable<T> GetDeleted<T>(IRepository<T> repo)
                                                            where T : IDbModel
        {
            Guard.WhenArgument(repo, "repo").IsNull().Throw();

            return repo.GetAll((x) => x.IsDeleted);
        }

        protected virtual bool IsValid<T>(T item)
                                where T : IDbModel
        {
            return !(item == null);
        }
    }
}