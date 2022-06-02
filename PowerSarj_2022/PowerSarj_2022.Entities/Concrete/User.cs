using PowerSarj_2022.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PowerSarj_2022.Entities.Concrete
{
    public class User : IEntity
    {

        // Sistemdeki userlar (otomatları kullanan kullanıcılar yani )
            public string _id { get; set; }  // PK 
            public string userid { get; set; }  // string olması gerekiyo
            public string cardid { get; set; }
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

    }
}
