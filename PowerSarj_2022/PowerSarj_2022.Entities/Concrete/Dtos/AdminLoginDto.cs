using PowerSarj_2022.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerSarj_2022.Entities.Concrete.Dtos
{
    public class AdminLoginDto :IDto
    {
        public string username { get; set; }
        public string password { get; set; }

    }
}
