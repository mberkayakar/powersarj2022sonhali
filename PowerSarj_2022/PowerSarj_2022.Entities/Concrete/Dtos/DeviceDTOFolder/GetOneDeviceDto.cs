using PowerSarj_2022.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerSarj_2022.Entities.Concrete.Dtos.DeviceDTOFolder
{
    public class GetOneDeviceDto : IDto
    {
        public string _id { get; set; }
        public string deviceid { get; set; }
        public string location { get; set; }
        public string type { get; set; }
        public List<OperationListDto> operations { get; set; }
        public List<string> allowedsites { get; set; }
        public string site { get; set; }
        public string state { get; set; } 
        public decimal price { get; set; }
        public string charginguser { get; set; }
        public string mobilecharging { get; set; }
        public string devicename { get; set; }
        public DateTime date { get; set; }

         
    }
}
