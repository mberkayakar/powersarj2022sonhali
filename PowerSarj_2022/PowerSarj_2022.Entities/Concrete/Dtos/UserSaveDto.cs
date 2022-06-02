using PowerSarj_2022.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerSarj_2022.Entities.Concrete.Dtos
{
    public class UserSaveDto : IDto
    {

        public decimal balance { get; set; }
        public string cardid { get; set; }
        public DateTime date { get; set; }
        public List<string> devices { get; set; }
        public List<Operation> operations { get; set; }
        public string password { get; set; }
        public string site { get; set; }
        public string userId { get; set; }
        public string username { get; set; }

    }
}
