using PowerSarj_2022.Business.Abstract;
using PowerSarj_2022.Core.DataAccess.Abstract;
using PowerSarj_2022.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PowerSarj_2022.Business.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class , IEntity , new()
    {

        private readonly IGenericRepository<T> _genericRepository;

        public GenericManager(IGenericRepository<T> genericRepository)
        {
            _genericRepository  = genericRepository;
        }

        public void Add(T entity)
        {
            _genericRepository.Add(entity);
        }

        public void Delete(T entity)
        {
            _genericRepository.Delete(entity);  
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> where = null)
        {


            return (where != null) ? _genericRepository.GetAll(where) : _genericRepository.GetAll();


        }

        public IEnumerable<T> GetAllWithİnclude(Expression<Func<T, bool>> where = null, params Expression<Func<T, object>>[] includeProperty)
        {
            return _genericRepository.GetAllWıthInclude(where, includeProperty);
        }

        public T GetObject(Expression<Func<T, bool>> where = null)
        {
            return (where != null) ? _genericRepository.GetObject(where) : _genericRepository.GetObject();

        }

        public void Update(T entity)
        {
            _genericRepository.Update(entity);
        }
    }
}
