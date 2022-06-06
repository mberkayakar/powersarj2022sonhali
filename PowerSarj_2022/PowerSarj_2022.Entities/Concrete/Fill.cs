
using PowerSarj_2022.Core.Entities;
using System;

namespace PowerSarj_2022.Entities.Concrete
{
    public class Fill : IEntity
    {
        public string _id { get; set; }
        public decimal amount { get; set; }
        public decimal lastbalance { get; set; }
        public string admin { get; set; }
        public DateTime date  { get; set; }




        // navigation property


        //public int userid { get; set; }
        public virtual User user { get; set; }



    }
}
