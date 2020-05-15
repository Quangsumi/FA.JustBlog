using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace FA.JustBlog.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> DbSet { get; }

        DbContext DbContext { get; set; }

        IQueryable<T> GetAll();

        IQueryable<T> GetMany(Expression<Func<T, bool>> predicate);

        T GetById(int id);

        T Get(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entities);

        void Update(T entity);
    }
}