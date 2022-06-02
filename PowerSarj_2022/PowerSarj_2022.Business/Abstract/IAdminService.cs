using PowerSarj_2022.Business.Abstract;
using PowerSarj_2022.Entities.Concrete;
using PowerSarj_2022.Entities.Concrete.Dtos.AdminDtoFolder;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PowerSarj_2022.DataAccess.Abstract
{
    public interface IAdminService  : IGenericService<Admin>
    {
        Task<GetAdminDto> Authenticate(string username, string password);
        IEnumerable<List<GetAdminDto>> GetAll();

    }
}
