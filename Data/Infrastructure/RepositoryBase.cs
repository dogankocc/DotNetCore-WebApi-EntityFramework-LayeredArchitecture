using DijitalTestApi.Data;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.Infrastructure
{
    public abstract class RepositoryBase<T> where T : BaseEntity
    {
        #region Properties

        private ApplicationDBContext dataContext;

        private readonly DbSet<T> dbSet;

        protected ApplicationDBContext DbContext { get { return dataContext; } }

        #endregion

        protected RepositoryBase(ApplicationDBContext dbContext)

        {

            dataContext = dbContext;

            dbSet = DbContext.Set<T>();

        }

        #region Implementation

        public virtual void Add(T entity)

        {

            dbSet.Add(entity);

        }

        public virtual void Update(T entity)

        {

            dbSet.Attach(entity);

            dataContext.Entry(entity).State = EntityState.Modified;

        }

        public virtual void Delete(T entity)

        {

            dbSet.Remove(entity);

        }

        public virtual void Delete(Expression<Func<T, bool>> where)

        {

            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();

            foreach (T obj in objects)

                dbSet.Remove(obj);

        }

        public virtual T GetById(long id, params string[] navigations)

        {

            IQueryable<T> set = dbSet.AsQueryable();

            foreach (string nav in navigations)

                set = set.Include(nav);


            return set.FirstOrDefault(f => f.Id == id);

        }

        public virtual IEnumerable<T> GetAll(params string[] navigations)

        {

            var set = dbSet.AsQueryable();

            foreach (string nav in navigations)

                set = set.Include(nav);

            return set.AsEnumerable();

        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where, params string[] navigations)

        {

            var set = dbSet.AsQueryable();

            foreach (string nav in navigations)

                set = set.Include(nav);

            return set.Where(where).AsEnumerable();

        }

        public T Get(Expression<Func<T, bool>> where, params string[] navigations)

        {

            var set = dbSet.AsQueryable();

            foreach (string nav in navigations)

                set = set.Include(nav);

            return set.Where(where).FirstOrDefault<T>();

        }

        #endregion

    }
}
