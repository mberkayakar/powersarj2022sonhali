using PowerSarj_2022.Core.Entities;
using System;
using System.Collections.Generic;

namespace PowerSarj_2022.Entities.Concrete
{
    public class Admin :IEntity
    {
        public string _id { get; set; }
        public string adminid{ get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string username { get; set; }
        public string site { get; set; }
        public string password { get; set; }
        public string  mail { get; set; }
        public string tel { get; set; }
        public List<Device> devices { get; set; }
        public DateTime lastlogin { get; set; }
    }
}
