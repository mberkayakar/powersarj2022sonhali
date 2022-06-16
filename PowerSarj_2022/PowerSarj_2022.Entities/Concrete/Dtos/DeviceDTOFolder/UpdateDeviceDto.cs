using PowerSarj_2022.Core.Entities.Abstract;
using System.Collections.Generic;

namespace PowerSarj_2022.Entities.Concrete.Dtos.DeviceDTOFolder
{
    public class UpdateDeviceDto : IDto
    {
        public string deviceid { get; set; }
        public string location { get; set; }
        public string type{ get; set; }
        public List<string> allowedsites { get; set; }
        public List<OperationListDto> operations { get; set; }

        //operations: data.operations,
        //    mobilecharging: data.mobilecharging,
        //    site: userSite,
        //    price:parseFloat(data.price)
    }
}
