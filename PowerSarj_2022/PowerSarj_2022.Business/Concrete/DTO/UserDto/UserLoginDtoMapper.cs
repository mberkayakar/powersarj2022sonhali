using AutoMapper;
using PowerSarj_2022.Entities.Concrete;
using PowerSarj_2022.Entities.Concrete.Dtos;
using PowerSarj_2022.Entities.Concrete.Dtos.UserDtoFolder;

namespace PowerSarj_2022.Business.Concrete.DTO.UserDto
{
    public class UserLoginDtoMapper : Profile
    {
        public UserLoginDtoMapper()
        {
            CreateMap<UserLoginModel, User>().ForPath(x => x.devices, opt => opt.Ignore()).ReverseMap() ;
            //CreateMap<OperationListDto, Operation>().ForPath(x=> x.user._id , opt=> opt.MapFrom(x=> x.userid));

        }
    }
}
