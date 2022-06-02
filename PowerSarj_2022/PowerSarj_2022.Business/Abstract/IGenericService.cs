using PowerSarj_2022.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PowerSarj_2022.Business.Abstract
{
    public interface IGenericService <T>  where T : class , IEntity, new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetObject(Expression<Func<T, bool>> where = null);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> where = null);
        IEnumerable<T> GetAllWithİnclude(Expression<Func<T, bool>> where = null, params Expression<Func<T, object>>[] includeProperty);

    }
}
