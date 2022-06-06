using PowerSarj_2022.Core.Entities.Abstract;
using PowerSarj_2022.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace PowerSarj_2022.Business.Concrete.DTO
{
    public class AddOperationFromUser : IDto
    {
        public string id { get; set; }
        public string operation { get; set; }
        public decimal amount { get; set; }
        public decimal lastbalance { get; set; }
        public string admin { get; set; }
        public DateTime date { get; set; }

        //public List<Fill> fills { get; set; }  // Operasyon listesi 


    }
}
