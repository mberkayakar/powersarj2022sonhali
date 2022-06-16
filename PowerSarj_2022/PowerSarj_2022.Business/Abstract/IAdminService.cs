using PowerSarj_2022.Business.Abstract;
using PowerSarj_2022.Entities.Concrete;
using PowerSarj_2022.Entities.Concrete.Dtos.AdminDtoFolder;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PowerSarj_2022.DataAccess.Abstract
{
    public interface IAdminService  : IGenericService<Admin>
    {
        IEnumerable<GetAdminDto> Authenticate(string username, string password);
        Admin Update(AdminUpdateDto adminUpdateDto, string id);

    }
}
