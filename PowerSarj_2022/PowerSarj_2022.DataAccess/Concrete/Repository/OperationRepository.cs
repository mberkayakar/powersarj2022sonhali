using Microsoft.EntityFrameworkCore;
using PowerSarj_2022.Core.DataAccess.Concrete;
using PowerSarj_2022.DataAccess.Abstract;
using PowerSarj_2022.Entities.Concrete;

namespace PowerSarj_2022.DataAccess.Concrete.Repository
{
    public class OperationRepository : GenericRepository<Operation>, IOperationRepository
    {


        public OperationRepository(DbContext db) : base(db)
        {
        }
    }
}
