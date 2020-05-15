using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FA.JustBlog.Core.Services
{
    public interface IService<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetMany(Expression<Func<T, bool>> predicate);
        int Add(T entity);
        int Update(T entity);
        bool Delete(T entity);
        int Count();
        T Find(int id);
    }
}
