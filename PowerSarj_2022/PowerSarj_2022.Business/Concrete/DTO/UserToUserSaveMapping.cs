using AutoMapper;
using PowerSarj_2022.Entities.Concrete;
using PowerSarj_2022.Entities.Concrete.Dtos;

namespace PowerSarj_2022.Business.Concrete.DTO
{
    public class UserToUserSaveMapping : Profile
    {
        public UserToUserSaveMapping()
        {
            CreateMap<UserSaveDto, User>().ForMember(x => x.balance, dto => dto.MapFrom(x => x.balance)).ReverseMap();
            CreateMap<UserSaveDto, User>().ForMember(x => x.cardid, dto => dto.MapFrom(x => x.cardid)).ReverseMap();
            CreateMap<UserSaveDto, User>().ForMember(x => x.date, dto => dto.MapFrom(x => x.date)).ReverseMap();
            CreateMap<UserSaveDto, User>().ForMember(x => x.operations, dto => dto.MapFrom(x => x.operations)).ReverseMap();
            CreateMap<UserSaveDto, User>().ForMember(x => x.password, dto => dto.MapFrom(x => x.password)).ReverseMap();
            CreateMap<UserSaveDto, User>().ForMember(x => x.site, dto => dto.MapFrom(x => x.site)).ReverseMap();
            CreateMap<UserSaveDto, User>().ForMember(x => x.userid, dto => dto.MapFrom(x => x.userId)).ReverseMap();
            CreateMap<UserSaveDto, User>().ForMember(x => x.username, dto => dto.MapFrom(x => x.username)).ReverseMap();
            CreateMap<UserSaveDto, User>().ForMember(x => x.devices, dto => dto.Ignore()).ReverseMap();
         
        }
    }
}
