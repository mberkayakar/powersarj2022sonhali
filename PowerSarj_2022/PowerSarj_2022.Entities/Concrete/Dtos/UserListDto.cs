using PowerSarj_2022.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerSarj_2022.Entities.Concrete.Dtos
{
    public class UserListDto : IDto
    {

        public string _id { get; set; }
        public string userid { get; set; }
        public string cardid { get; set; }
        public string username { get; set; }
        public string site { get; set; }
        public string password { get; set; }

        public List<string> devices { get; set; }
        public List<Operation> operations { get; set; }
        public List<Fill> fills { get; set; }

        public DateTime date { get; set; }
        public int __v { get; set; }
        public decimal balance { get; set; }
        public string chargingdevice { get; set; }
        public DateTime? updatedAt { get; set;  }





        /*
         
 
            public string username { get; set; }    // unique olacak 
            public string site { get; set; }  // bilmiyorum 
            public string password { get; set; }
            public virtual List<Device> devices { get; set; }  // sadece string olarak isim geliyo oda device id nin kendi ismi // yüksek ihtimal dto kullanabilirm 
            public virtual List<Operation> operations { get; set; }  // Operasyon listesi 
            public virtual List<Fill> fills { get; set; } // 1 user in  birden çok fill i olabilir 
            public DateTime date { get; set; }
            public int __v { get; set; }
            public decimal balance { get; set; }
            public string chargingdevice { get; set; }
            public DateTime? updatedAt { get; set; }


         */
    }

    public class OperationDto
    {
     

        public string operation { get; set; }
        public double energy { get; set; }
        public decimal amount { get; set; }
        public int duration { get; set; }
        public DateTime date { get; set; }



    }
}
