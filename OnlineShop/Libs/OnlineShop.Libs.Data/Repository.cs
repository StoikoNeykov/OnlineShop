using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using OnlineShop.Libs.Data.Contracts;
using System.Data.Entity;
using System.Linq;
using OnlineShop.Libs.Models.Contracts;

namespace OnlineShop.Libs.Data
{
    public class Repository<T> : IRepository<T>
        where T : class, IDbModel
    {
        private readonly IOnlineShopDbContext dbContext;
        private readonly IDbSet<T> dbSet;

        public Repository(IOnlineShopDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("DbContext");
            }

            this.dbContext = dbContext;
            var set = dbContext.Set<T>();

            if (set == null)
            {
                throw new ArgumentNullException("DbSet");
            }

            this.dbSet = set;
        }

        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }

            var entry = this.dbContext.GetStateful(entity);
            entry.State = EntityState.Added;
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }

            var entry = this.dbContext.GetStateful(entity);
            entry.State = EntityState.Deleted;
        }

        public IEnumerable<T> GetAll()
        {
            return this.dbSet.ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return this.dbSet
                        .Where(filter)
                        .ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter, int page, int pageSize)
        {
            return this.dbSet
                        .Where(filter)
                        .Skip(page * pageSize)
                        .Take(pageSize)
                        .ToList();
        }

        public IEnumerable<T> GetAll<T1>(Expression<Func<T, bool>> filter, Expression<Func<T, T1>> orderBy)
        {
            return this.dbSet
                        .Where(filter)
                        .OrderBy(orderBy)
                        .ToList();
        }

        public IEnumerable<T> GetAll<T1>(Expression<Func<T, bool>> filter, Expression<Func<T, T1>> orderBy, int page, int pageSize)
        {
            return this.dbSet
                        .Where(filter)
                        .OrderBy(orderBy)
                        .Skip(page * pageSize)
                        .Take(pageSize)
                        .ToList();
        }

        public IEnumerable<TResult> GetAll<T1, TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, T1>> orderBy, Expression<Func<T, TResult>> select)
        {
            return this.GetAll(filter, orderBy, select, 0, int.MaxValue);
        }

        public IEnumerable<TResult> GetAll<T1, TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, T1>> orderBy, Expression<Func<T, TResult>> select, int page, int pageSize)
        {
            IQueryable<T> result = this.dbSet.OrderBy(x => x.Id);

            if (filter != null)
            {
                result = result.Where(filter);
            }

            if (orderBy != null)
            {
                result = result.OrderBy(orderBy);
            }

            result = result
                        .Skip(page * pageSize)
                        .Take(pageSize);

            if (select != null)
            {
                return result.Select(select).ToList();
            }

            return result.OfType<TResult>().ToList();
        }

        public T GetById(object id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("Id");
            }

            return this.dbSet.Find(id);
        }

        public IEnumerable<T> GetDeleted()
        {
            return this.dbSet
                        .Where(x => x.IsDeleted)
                        .ToList();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }

            var entry = this.dbContext.GetStateful(entity);
            entry.State = EntityState.Modified;
        }
    }
}
