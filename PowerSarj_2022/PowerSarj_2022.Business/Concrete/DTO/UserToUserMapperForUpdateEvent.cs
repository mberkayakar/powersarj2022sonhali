using AutoMapper;
using PowerSarj_2022.Entities.Concrete;

namespace PowerSarj_2022.Business.Concrete.DTO
{
    public class UserToUserMapperForUpdateEvent : Profile
    {
        public UserToUserMapperForUpdateEvent()
        {
            CreateMap<User, User>().ForMember(x => x.balance, dto => dto.MapFrom(x => x.balance));
            CreateMap<User, User>().ForMember(x => x.cardid, dto => dto.MapFrom(x => x.cardid));
            CreateMap<User, User>().ForMember(x => x.date, dto => dto.MapFrom(x => x.date));
            CreateMap<User, User>().ForMember(x => x.operations, dto => dto.MapFrom(x => x.operations));
            CreateMap<User, User>().ForMember(x => x.password, dto => dto.MapFrom(x => x.password));
            CreateMap<User, User>().ForMember(x => x.site, dto => dto.MapFrom(x => x.site));
            //CreateMap<User, User>().ForMember(x => x.userid, dto => dto.MapFrom(x => x.userid)).ReverseMap(); // sebebei userid şimdilik bende primary key bu sebepten ötürü bu şekil bir yola gittim .
            CreateMap<User, User>().ForMember(x => x.username, dto => dto.MapFrom(x => x.username));
            CreateMap<User, User>().ForMember(x => x.devices, dto => dto.Ignore());



            // maplenmesini istemediğim değişkenler. Sebebi ise user bilgilerin Device Fills Ve Operation Bilgilerini kaybetmemiz muhtemel bir senaryodur. 
            CreateMap<User, User>().ForMember(x => x.devices, dto => dto.MapFrom(x=> x.devices) );
            CreateMap<User, User>().ForMember(x => x.fills, dto => dto.MapFrom(x => x.fills));
            CreateMap<User, User>().ForMember(x => x.operations, dto => dto.MapFrom(x => x.operations));


        }

    }
}
