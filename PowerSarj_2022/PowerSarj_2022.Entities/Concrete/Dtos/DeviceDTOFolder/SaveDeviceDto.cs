using PowerSarj_2022.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerSarj_2022.Entities.Concrete.Dtos.DeviceDTOFolder
{
    public class SaveDeviceDto : IDto
    {

        public string deviceid { get; set; }
        public string location { get; set; }
        public string site { get; set; }
        public string type { get; set; }
        public List<string> allowedsites { get; set; }
        public List<Operation> operations { get; set; }
    }
}
