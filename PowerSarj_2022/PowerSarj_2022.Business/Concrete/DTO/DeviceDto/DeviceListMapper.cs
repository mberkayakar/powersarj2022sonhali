using AutoMapper;
using PowerSarj_2022.Entities.Concrete;
using PowerSarj_2022.Entities.Concrete.Dtos;

namespace PowerSarj_2022.Business.Concrete.DTO.DeviceDto
{
    public class DeviceListMapper : Profile
    {
        public DeviceListMapper()
        {
            CreateMap<ListDeviceDto, Device>().ForMember(x => x._id, dto => dto.MapFrom(x=> x._id)).ReverseMap();
            CreateMap<ListDeviceDto, Device>().ForMember(x => x.allowedSites, dto => dto.Ignore()).ReverseMap();
            CreateMap<OperationListDto, Operation>().ForMember(x => x.user, dto => dto.Ignore()).ReverseMap();
            CreateMap<OperationListDto, Operation>().ForMember(x => x.device, dto => dto.Ignore()).ReverseMap();


        }
    }
}
