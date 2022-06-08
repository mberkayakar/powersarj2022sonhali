using PowerSarj_2022.Core.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace PowerSarj_2022.Entities.Concrete.Dtos.UserDtoFolder
{
    public class UserLoginModel : IDto
    {
        public string _id { get; set; }  
        public string userid { get; set; }  
        public string cardid { get; set; }
        public string username { get; set; }    
        public string site { get; set; }  
        public string password { get; set; }
        //public virtual List<string> devices { get; set; }  
        public DateTime date { get; set; }
        public int __v { get; set; }
        public decimal balance { get; set; }
        public string chargingdevice { get; set; }
        public DateTime? updatedAt { get; set; }


    }
}
