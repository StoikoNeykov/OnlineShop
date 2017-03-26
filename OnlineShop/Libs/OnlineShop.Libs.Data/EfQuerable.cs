using Bytes2you.Validation;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Models.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace OnlineShop.Libs.Data
{
    public class EfQuerable<TEntity> : IEfQuerable<TEntity>, IQueryable<TEntity>, IEnumerable<TEntity> where TEntity : class, IDbModel
    {
        private readonly IDbSet<TEntity> dbSet;
        private readonly IEfEntryProvider entryProvider;

        public EfQuerable(IEfOnlineShopDbContext dbContext)
        {
            Guard.WhenArgument(dbContext, nameof(dbContext)).IsNull().Throw();

            this.dbSet = dbContext.GetSet<TEntity>();
            this.entryProvider = dbContext;
        }

        public virtual IQueryable<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> include)
        {
            Guard.WhenArgument(include, nameof(include)).IsNull().Throw();

            return this.dbSet.Include(include);
        }

        public virtual TEntity FindByKey(params object[] keyValues)
        {
            return this.dbSet.Find(keyValues);
        }

        public virtual TEntity Add(TEntity entity)
        {
            Guard.WhenArgument(entity, nameof(entity)).IsNull().Throw();

            return this.dbSet.Add(entity);
        }

        /// <summary>
        /// Set entity IsDeleted=true. 
        /// Do not change. Not tastable coz couple with Entity Framework ... for now
        /// </summary>
        /// <param name="entity">Entity to hide</param>
        public virtual void Hide(TEntity entity)
        {
            Guard.WhenArgument(entity, nameof(entity)).IsNull().Throw();
            
            var entry = this.AttachIfDetached(entity);

            entity.IsDeleted = true;

            entry.State = EntityState.Modified;
        }

        public virtual TEntity Remove(TEntity entity)
        {
            Guard.WhenArgument(entity, nameof(entity)).IsNull().Throw();
            
            return this.dbSet.Remove(entity);
        }

        public virtual Expression Expression => this.dbSet.Expression;

        public virtual Type ElementType => this.dbSet.ElementType;

        public virtual IQueryProvider Provider => this.dbSet.Provider;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.dbSet.GetEnumerator();
        }

        public virtual IEnumerator<TEntity> GetEnumerator()
        {
            return this.dbSet.GetEnumerator();
        }

        protected virtual DbEntityEntry AttachIfDetached(TEntity entity)
        {
            var entry = this.entryProvider.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.dbSet.Attach(entity);
            }

            return entry;
        }
    }
}
