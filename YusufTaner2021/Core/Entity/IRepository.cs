using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Entity
{
    public interface IRepository<T> where T:class,IEntity,new()
    {
        List<T> GetList(Expression<Func<T,bool>> filter);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

    }
}
