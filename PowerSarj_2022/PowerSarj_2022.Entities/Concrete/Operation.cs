using PowerSarj_2022.Core.Entities;
using System;



namespace PowerSarj_2022.Entities.Concrete
{
    public class Operation : IEntity
    {


        public string _id { get; set; }
        public string operation { get; set; }
        public double energy { get; set; }
        public int MyProperty { get; set; }
        public decimal amount { get; set; }
        // dakika cinsinden
        public int duration { get; set; }
        public DateTime date { get; set; }

        // Navigation Properties 
        //public int userid { get; set; }
        public virtual User user { get; set; }

        public int deviceid { get; set; }
        public virtual Device device { get; set; }






    }
}
