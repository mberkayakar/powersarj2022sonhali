using AutoMapper;
using PowerSarj_2022.Entities.Concrete;
using PowerSarj_2022.Entities.Concrete.Dtos;

namespace PowerSarj_2022.Business.Concrete.DTO
{
    public class UserDTOtoUserMapper : Profile
    {

        public UserDTOtoUserMapper()
        {


            //CreateMap<UserUpdateDTO, User>().ForMember(x => x.balance, dto => dto.MapFrom(x => x.balance)).ReverseMap();
            //CreateMap<UserUpdateDTO, User>().ForMember(x => x.cardid, dto => dto.MapFrom(x => x.cardid)).ReverseMap();
            //CreateMap<UserUpdateDTO, User>().ForMember(x => x.operations, dto => dto.Ignore()).ReverseMap();
            //CreateMap<UserUpdateDTO, User>().ForMember(x => x.devices, dto => dto.Ignore()).ReverseMap();
            //CreateMap<UserUpdateDTO, User>().ForMember(x => x.fills, dto => dto.Ignore()).ReverseMap();
            //CreateMap<UserUpdateDTO, User>().ForMember(x => x.password, dto => dto.MapFrom(x => x.password)).ReverseMap();
            //CreateMap<UserUpdateDTO, User>().ForMember(x => x.site, dto => dto.MapFrom(x => x.site)).ReverseMap();
            //CreateMap<UserUpdateDTO, User>().ForMember(x => x.username, dto => dto.MapFrom(x => x.username)).ReverseMap();


            CreateMap<UserUpdateDTO, User>().ForMember(x => x.devices, dto => dto.Ignore()).ReverseMap();
            CreateMap<UserUpdateDTO, User>().ForMember(x => x.fills, dto => dto.Ignore()).ReverseMap();
            CreateMap<UserUpdateDTO, User>().ForMember(x => x.operations, dto => dto.Ignore()).ReverseMap();


        }


    }
}
