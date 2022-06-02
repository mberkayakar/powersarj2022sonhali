using Microsoft.EntityFrameworkCore;
using PowerSarj_2022.Core.DataAccess.Concrete;
using PowerSarj_2022.DataAccess.Abstract;
using PowerSarj_2022.Entities.Concrete;

namespace PowerSarj_2022.DataAccess.Concrete.Repository
{
    public class FillRepository : GenericRepository<Fill> , IFillRepository
    {
        public FillRepository(DbContext db) : base(db)
        {
        }
    }
}
