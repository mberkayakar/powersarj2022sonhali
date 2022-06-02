using PowerSarj_2022.Core.DataAccess.Abstract;
using PowerSarj_2022.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PowerSarj_2022.DataAccess.Abstract
{
    public interface IUserRepository : IGenericRepository<User>
    {


        IEnumerable<User> GetAllUserİnformation (Expression<Func<User, bool>> filter, params Expression<Func<User, object>>[] children);

    }
}
