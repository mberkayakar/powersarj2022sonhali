using PowerSarj_2022.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerSarj_2022.Entities.Concrete.Dtos
{
    public class UserUpdateDTO : IDto
    {
   
        public string _id { get; set; }   
        public string userid { get; set; }   
        public string cardid { get; set; }
        public string username { get; set; }     
        public string site { get; set; }   
        public List<string> devices { get; set; }
        public string password { get; set; }
        public int __v { get; set; }
        public decimal balance { get; set; }
        public string chargingdevice { get; set; }
        public DateTime? updatedAt { get; set; }





        // 









    }
}
