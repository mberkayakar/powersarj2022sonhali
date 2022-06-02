using Microsoft.EntityFrameworkCore;
using PowerSarj_2022.Core.DataAccess.Concrete;
using PowerSarj_2022.DataAccess.Abstract;
using PowerSarj_2022.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PowerSarj_2022.DataAccess.Concrete.Repository
{

    public class UserRepository : GenericRepository<User>, IUserRepository
    {

        private readonly DbContext _dbContext;
        public UserRepository(DbContext db) : base(db)
        {

            _dbContext = db;
        }

        


        public IEnumerable<User> GetAllUserİnformation(Expression<Func<User, bool>> filter, params Expression<Func<User, object>>[] children)
        {
            var query = _dbContext.Set<User>().AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (children.Any())  
            {
                foreach (var item in children)
                {
                    query = query.Include(item);  
                }
            }
 

             return query.ToList();


        }
    }
}
