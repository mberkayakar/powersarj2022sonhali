using PowerSarj_2022.Core.Entities.Abstract;
using System;

namespace PowerSarj_2022.Entities.Concrete.Dtos
{
    public class OperationListDto : IDto
    {

        public string userid { get; set; }
        public string operation { get; set; }
        public double energy { get; set; }
        public decimal amount { get; set; }
        // dakika cinsinden
        public int duration { get; set; }
        public DateTime date { get; set; }

        // Navigation Properties 
        
    }
}
