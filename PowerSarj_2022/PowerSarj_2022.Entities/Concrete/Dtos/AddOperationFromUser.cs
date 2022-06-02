using PowerSarj_2022.Core.Entities.Abstract;
using PowerSarj_2022.Entities.Concrete;
using System.Collections.Generic;

namespace PowerSarj_2022.Business.Concrete.DTO
{
    public class AddOperationFromUser : IDto
    {
        public string userid { get; set; }

        public List<Fill> fills { get; set; }  // Operasyon listesi 



    }
}
