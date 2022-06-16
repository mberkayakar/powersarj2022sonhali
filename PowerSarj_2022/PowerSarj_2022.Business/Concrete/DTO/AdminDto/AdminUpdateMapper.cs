using AutoMapper;
using PowerSarj_2022.Entities.Concrete;
using PowerSarj_2022.Entities.Concrete.Dtos.AdminDtoFolder;

namespace PowerSarj_2022.Business.Concrete.DTO.AdminDto
{
    public class AdminUpdateMapper : Profile
    {
        public AdminUpdateMapper()
        {
            CreateMap<AdminUpdateDto, Admin>().ForMember(x => x.tel, opt => opt.MapFrom(x => x.tel)).ReverseMap();
            CreateMap<AdminUpdateDto, Admin>().ForMember(x => x.adminid, opt => opt.MapFrom(x => x.adminid)).ReverseMap();
            CreateMap<AdminUpdateDto, Admin>().ForMember(x => x.name, opt => opt.MapFrom(x => x.adsoyad)).ReverseMap();
            CreateMap<AdminUpdateDto, Admin>().ForMember(x => x.site, opt => opt.MapFrom(x => x.site)).ReverseMap();
            CreateMap<AdminUpdateDto, Admin>().ForMember(x => x.password, opt => opt.MapFrom(x => x.password)).ReverseMap();
            CreateMap<AdminUpdateDto, Admin>().ForMember(x => x.tel, opt => opt.MapFrom(x => x.tel)).ReverseMap();
            CreateMap<AdminUpdateDto, Admin>().ForMember(x => x.devices, opt => opt.Ignore()).ReverseMap();






    }
    }
}
