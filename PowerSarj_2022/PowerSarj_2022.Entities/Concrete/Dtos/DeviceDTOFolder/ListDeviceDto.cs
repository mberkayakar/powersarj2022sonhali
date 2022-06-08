using PowerSarj_2022.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerSarj_2022.Entities.Concrete.Dtos
{
    public class ListDeviceDto : IDto
    {

        public string _id { get; set; }
        public string deviceid { get; set; }
        public string location { get; set; }

        // AC - DC olma durumu 
        public string type { get; set; }

        public virtual List<OperationListDto> operations { get; set; }
        public virtual List<string> allowedSites { get; set; }
        public List<string> devices { get; set; }
        public string site { get; set; }
        public string state { get; set; } // sanırım 0 1 gibi bişi 
        public decimal price { get; set; }
        public string charginguser { get; set; }
        public string mobilecharging { get; set; }
        public string devicename { get; set; }
        public DateTime date { get; set; }
        public string userid { get; set; }



    }
}
