using AutoMapper;
using PowerSarj_2022.Business.Concrete;
using PowerSarj_2022.Business.Concrete.DTO.AdminDto;
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

        public IEnumerable<GetAdminDto>Authenticate(string username, string password)
        {
            var user  =  _adminService.GetObjectWithInclude(where: x=> x.username ==username && x.password == password , includeProperty : y=> y.devices);

            if (user != null)
            {

                var configuration = new MapperConfiguration(opt =>
                {
                    opt.AddProfile(new GetAdminMapper());
                });


                var mapper = configuration.CreateMapper();
                var model = mapper.Map<GetAdminDto>(user);


                List<string> deviceliset = new List<string>();
                foreach (var item in user.devices)
                {
                    deviceliset.Add(item.deviceid);
                }
                model.devices = deviceliset;
                model.adsoyad = user.name + "  " + user.surname;

                List<GetAdminDto> admins = new List<GetAdminDto>();
                admins.Add(model);

                  return  admins;

            }
            else
            {
                return null;
            }
        }
        
        
        public  IEnumerable<Admin> GetAll()
        {
            return  _adminService.GetAll() ;
        }

        
        
        IEnumerable<List<GetAdminDto>> IAdminService.GetAll()
        {
            throw new System.NotImplementedException();
        }
    }




}

