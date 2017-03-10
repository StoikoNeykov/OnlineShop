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

        public EfQuerable(IDbSet<TEntity> dbSet, IEfEntryProvider entryProvider)
        {
            Guard.WhenArgument(dbSet, nameof(dbSet)).IsNull().Throw();
            Guard.WhenArgument(entryProvider, nameof(entryProvider)).IsNull().Throw();

            this.dbSet = dbSet;
            this.entryProvider = entryProvider;
        }

        public IQueryable<TEntity> GetAvailabe => this.dbSet.Where(x => x.IsDeleted == false);

        public virtual TEntity FindByKey(params object[] keyValues)
        {
            return this.dbSet.Find(keyValues);
        }

        public virtual TEntity Add(TEntity entity)
        {
            return this.dbSet.Add(entity);
        }

        /// <summary>
        /// Set entity IsDeleted=true. 
        /// Do not change. Not tastable coz couple with Entity Framework ... for now
        /// </summary>
        /// <param name="entity">Entity to hide</param>
        public virtual void Hide(TEntity entity)
        {
            var entry = this.AttachIfDetached(entity);

            entity.IsDeleted = true;

            entry.State = EntityState.Modified;
        }

        public virtual TEntity Remove(TEntity entity)
        {
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
