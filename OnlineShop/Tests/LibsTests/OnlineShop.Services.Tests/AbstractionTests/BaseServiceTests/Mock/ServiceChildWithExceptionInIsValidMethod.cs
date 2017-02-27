using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data.Factories;
using OnlineShop.Libs.Models.Contracts;
using OnlineShop.Services.Abstraction;
using System;

namespace OnlineShop.Libs.Services.Tests.AbstractionTests.BaseServiceTests.Mock
{
    public class ServiceChildWithSpecificIsValidMethod : BaseService
    {
        private readonly Func<IDbModel, bool> func;

        public ServiceChildWithSpecificIsValidMethod(IUnitOfWorkFactory unitOfWorkFactory, Func<IDbModel, bool> func)
            : base(unitOfWorkFactory)
        {
            this.func = func;
        }

        public virtual IUnitOfWorkFactory UnitOfWorkFactory
        {
            get
            {
                return base.UnitOfWorkFactory;
            }
        }
        
        public virtual void Add<T>(IRepository<T> repo, T item) where T : IDbModel
        {
            base.Add(repo, item);
        }

        public virtual void Update<T>(IRepository<T> repo, T item) where T : IDbModel
        {
             base.Update(repo, item);
        }

        public virtual void Hide<T>(IRepository<T> repo, T item) where T : IDbModel
        {
            base.Hide(repo, item);
        }

        public virtual void Delete<T>(IRepository<T> repo, T item) where T : IDbModel
        {
            base.Delete(repo, item);
        }

        protected override bool IsValid<T>(T item)
        {
            return this.func(item);
        }
    }
}
