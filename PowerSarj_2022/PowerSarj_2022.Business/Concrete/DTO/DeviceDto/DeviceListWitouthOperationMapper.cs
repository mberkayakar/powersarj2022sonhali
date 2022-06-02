using AutoMapper;
using PowerSarj_2022.Entities.Concrete;
using PowerSarj_2022.Entities.Concrete.Dtos.DeviceDTOFolder;

namespace PowerSarj_2022.Business.Concrete.DTO.DeviceDto
{
    public class DeviceListWitouthOperationMapper :  Profile
    {
        public DeviceListWitouthOperationMapper()
        {
            CreateMap<ListDeviceDtoNoOperation, Device>().ForMember(x => x.allowedSites, dto => dto.Ignore()).ReverseMap();

        }

    }
}
