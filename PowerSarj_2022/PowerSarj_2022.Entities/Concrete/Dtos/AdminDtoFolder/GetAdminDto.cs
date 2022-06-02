using PowerSarj_2022.Core.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace PowerSarj_2022.Entities.Concrete.Dtos.AdminDtoFolder
{
    public class GetAdminDto : IDto
    {
        public string adminid { get; set; }
        public string adsoyad { get; set; }
        public List<string> devices { get; set; }
        public DateTime? lastlogin { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public string site { get; set; }
        public string tel { get; set; }
        public string username { get; set; }
        public string _id { get; set; }


    }
}
