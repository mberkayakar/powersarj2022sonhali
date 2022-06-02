using PowerSarj_2022.Business.Concrete;
using PowerSarj_2022.Entities.Concrete;
using PowerSarj_2022.Entities.Concrete.Dtos.AdminDtoFolder;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PowerSarj_2022.DataAccess.Abstract
{
    public class AdminManager : GenericManager<Admin>, IAdminService
    {

        private readonly IAdminRepository _adminService;
        public AdminManager(IAdminRepository genericRepository) : base(genericRepository)
        {
            _adminService = genericRepository;
        }

        
        

        public async Task<GetAdminDto> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _adminService.GetObject(x=> x.username ==username && x.password == password));

            if (user == null)
                return null;

            else
            {

            }
        }

        public  IEnumerable<Admin> GetAll()
        {
            return  _adminService.GetAll() ;
        }
    }




}

