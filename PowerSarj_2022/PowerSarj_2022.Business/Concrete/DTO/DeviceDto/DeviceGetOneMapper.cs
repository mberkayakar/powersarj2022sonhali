using AutoMapper;
using PowerSarj_2022.Entities.Concrete;
using PowerSarj_2022.Entities.Concrete.Dtos;
using PowerSarj_2022.Entities.Concrete.Dtos.DeviceDTOFolder;

namespace PowerSarj_2022.Business.Concrete.DTO.DeviceDto
{
    public class DeviceGetOneMapper : Profile
    {
        public DeviceGetOneMapper()
        {
            CreateMap<GetOneDeviceDto, Device>().ForMember(x => x._id, dto => dto.MapFrom(x => x._id)).ReverseMap();
            CreateMap<GetOneDeviceDto, Device>().ForMember(x => x.allowedSites, dto => dto.Ignore()).ReverseMap();
            CreateMap<OperationListDto, Operation>().ForMember(x => x.user, dto => dto.Ignore()).ReverseMap();
            CreateMap<OperationListDto, Operation>().ForMember(x => x.device, dto => dto.Ignore()).ReverseMap();
            CreateMap<OperationListDto, Operation>().ForPath(x => x.user._id, dto => dto.MapFrom(x=> x.userid)).ReverseMap();
            
            // base teki property ile bir chiled proeperty eşleşmesi için map from yerine forpath kullanılmkatadır.     



        }
    }
}
