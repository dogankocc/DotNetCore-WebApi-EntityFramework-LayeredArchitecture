using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(Expression<Func<T, bool>> where);

        T GetById(long id, params string[] navigations);

        T Get(Expression<Func<T, bool>> where, params string[] navigations);

        IEnumerable<T> GetAll(params string[] navigations);

        IEnumerable<T> GetMany(Expression<Func<T, bool>> where, params string[] navigations);
    }
}
