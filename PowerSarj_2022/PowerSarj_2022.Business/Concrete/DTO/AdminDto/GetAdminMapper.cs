using AutoMapper;
using PowerSarj_2022.Entities.Concrete;
using PowerSarj_2022.Entities.Concrete.Dtos.AdminDtoFolder;

namespace PowerSarj_2022.Business.Concrete.DTO.AdminDto
{
    public class GetAdminMapper : Profile
    {
        public GetAdminMapper()
        {
            CreateMap<GetAdminDto, Admin>().ForMember(x => x.devices, dto => dto.Ignore()).ReverseMap();

            //CreateMap<GetAdminDto, Admin>().ForMember(x => x.name + " " +x.username, dto => dto.MapFrom(x => x.adsoyad));


        }
    }
}
