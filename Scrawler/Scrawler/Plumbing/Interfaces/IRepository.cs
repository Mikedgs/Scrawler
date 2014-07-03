using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Mindscape.LightSpeed;

namespace Scrawler.Plumbing.Interfaces
{
    public interface IRepository<T> where T : Entity<int>
    {
        IList<T> Get(Expression<Func<T, bool>> predicate);
        IList<T> GetAll();
        void Add(T entity);
        void DeleteAll();
        void Delete(T entity);
        T FindById(int id);
        void SaveChanges();
        void Dispose();
    }
}