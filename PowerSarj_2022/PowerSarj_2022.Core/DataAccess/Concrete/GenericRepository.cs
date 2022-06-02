using Microsoft.EntityFrameworkCore;
using PowerSarj_2022.Core.DataAccess.Abstract;
using PowerSarj_2022.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PowerSarj_2022.Core.DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class, IEntity, new()

    {


        private readonly DbContext _db;
        public GenericRepository(DbContext db)
        {
            _db = db;
        }


        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
            _db.SaveChanges();

        }

        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
            _db.SaveChanges();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> where = null)
        {
            if (where != null)
            {
                return _db.Set<T>().Where(where).ToList();
            }
            return _db.Set<T>().ToList();
        }

        public IEnumerable<T> GetAllWıthInclude(Expression<Func<T, bool>> where = null, params Expression<Func<T, object>>[] includeProperty)
        {

            IQueryable<T> model = _db.Set<T>();
            
            if (where != null)
            {
                model = model.Where(where);
            }

            if (includeProperty.Any()) 
            {
                foreach (var item in includeProperty)
                {
                    model = model.Include(item); 
                }
            }
            return model.ToList();
        }

        public T GetObject(Expression<Func<T, bool>> where = null)
        {

            if (where != null)
            {
                return _db.Set<T>().Where(where).FirstOrDefault();
            }
            return _db.Set<T>().FirstOrDefault();
        }

        public void Update(T entity)
        {
           _db.Entry(entity).State = EntityState.Modified;
           _db.SaveChanges();
        }
    }
}
