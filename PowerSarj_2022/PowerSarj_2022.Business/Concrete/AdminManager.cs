using AutoMapper;
using PowerSarj_2022.Business.Concrete;
using PowerSarj_2022.Business.Concrete.DTO.AdminDto;
using PowerSarj_2022.Entities.Concrete;
using PowerSarj_2022.Entities.Concrete.Dtos.AdminDtoFolder;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerSarj_2022.DataAccess.Abstract
{
    public class AdminManager : GenericManager<Admin>, IAdminService
    {

        private readonly IAdminRepository _adminService;
        private readonly IDeviceRepository _deviceRepository;

        public AdminManager(IAdminRepository genericRepository , IDeviceRepository devicereservice) : base(genericRepository)
        {
            _adminService = genericRepository;
            _deviceRepository = devicereservice;
            
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

        public Admin Update(AdminUpdateDto adminUpdateDto, string id)
        {
            var model = _adminService.GetObjectWithInclude(x => x._id == id, includeProperty: x => x.devices);
            if (model!=null)
            {
                model.mail = adminUpdateDto.mail;
                model.password = adminUpdateDto.password;
                model.username = adminUpdateDto.username;
                model.tel = adminUpdateDto.tel;
                model.devices.Clear() ;
                model.adminid = adminUpdateDto.adminid;

                foreach (var item in adminUpdateDto.devices)
                {
                    var device = _deviceRepository.GetAll().FirstOrDefault(x => x.deviceid == item);
                    if (device != null)
                    {
                        model.devices.Add(device);
                    }
                }

                _adminService.Update(model);


                return model;


            }
            return null;
        }
    }




}

