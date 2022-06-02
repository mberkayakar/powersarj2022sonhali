using AutoMapper;
using PowerSarj_2022.Entities.Concrete;
using PowerSarj_2022.Entities.Concrete.Dtos.DeviceDTOFolder;

namespace PowerSarj_2022.Business.Concrete.DTO.DeviceDto
{
    public class DeviceSaveMapper : Profile
    {
        public DeviceSaveMapper()
        {
            CreateMap<SaveDeviceDto, Device>().ForMember(x => x.allowedSites, dto => dto.Ignore()).ReverseMap();
            //CreateMap<SaveDeviceDto, Device>().ForMember(x => x.operations, dto => dto.Ignore()).ReverseMap();


        }
    }
}
