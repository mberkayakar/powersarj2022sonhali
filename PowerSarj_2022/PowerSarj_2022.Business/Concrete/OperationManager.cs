using Microsoft.EntityFrameworkCore;
using PowerSarj_2022.Business.Abstract;
using PowerSarj_2022.Business.Concrete;
using PowerSarj_2022.Core.DataAccess.Abstract;
using PowerSarj_2022.Core.DataAccess.Concrete;
using PowerSarj_2022.Entities.Concrete;

namespace PowerSarj_2022.DataAccess.Abstract
{
    public class OperationManager : GenericManager<Operation>, IOperationService
    {
        public OperationManager(IOperationRepository genericRepository) : base(genericRepository)
        {


        }
    }
}
