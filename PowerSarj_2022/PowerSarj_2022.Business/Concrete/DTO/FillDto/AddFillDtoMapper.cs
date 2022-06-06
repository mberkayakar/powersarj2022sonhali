using AutoMapper;
using PowerSarj_2022.Entities.Concrete;

namespace PowerSarj_2022.Business.Concrete.DTO.FillDto
{
    public class AddFillDtoMapper : Profile
    {
        public AddFillDtoMapper()
        {
            //CreateMap<AddOperationFromUser, Fill>();

            CreateMap<AddOperationFromUser, Fill>().ForMember(x => x.date, dto => dto.MapFrom(x => x.date)).ReverseMap();
            CreateMap<AddOperationFromUser, Fill>().ForMember(x => x.admin, dto => dto.MapFrom(x => x.admin)).ReverseMap();
            CreateMap<AddOperationFromUser, Fill>().ForMember(x => x.lastbalance, dto => dto.MapFrom(x => x.lastbalance)).ReverseMap();
            CreateMap<AddOperationFromUser, Fill>().ForMember(x => x.amount, dto => dto.MapFrom(x => x.amount)).ReverseMap();
            CreateMap<AddOperationFromUser, Fill>().ForMember(x => x._id, dto => dto.Ignore()).ReverseMap();




        }

    }
}
