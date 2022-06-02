using PowerSarj_2022.Business.Concrete;
using PowerSarj_2022.Entities.Concrete;

namespace PowerSarj_2022.DataAccess.Abstract
{
    public class FillManager : GenericManager<Fill>, IFillService
    {
        public FillManager(IFillRepository genericRepository) : base(genericRepository)
        {

        }
    }
}
