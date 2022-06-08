using PowerSarj_2022.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerSarj_2022.Entities.Concrete.Dtos.UserDtoFolder
{
    public class UserLoginDto : IDto
    {
        public string userid { get; set; }
        public string Password { get; set; }

       

    }
}
