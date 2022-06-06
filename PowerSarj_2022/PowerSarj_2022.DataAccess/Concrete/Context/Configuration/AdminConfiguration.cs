using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PowerSarj_2022.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace PowerSarj_2022.DataAccess.Concrete.Context.Configuration
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(c => c._id);
            builder.Property(c => c._id).ValueGeneratedOnAdd();


            //builder.Property(c => c._id).ValueGeneratedOnAdd();
            //builder.Property(c => c._id).HasColumnName("_id");
            //builder.Property(c => c.Name).HasColumnName("_id");

            builder.HasData(
                new Admin
                {
                    _id="MARSIS_ADMIN_1",
                    name="Berkay",
                    surname = "AKAR",
                    username="MBerkayAkar10",
                    password="1234",
                    adminid = "mberkayakar",
                    mail="m.berkay.akar@gmail.com",
                    site="WHITEROSE",
                    tel="0552 693 14 36",
                    //devices = new List<Device> { 
                    //    new Device { 
                    //        adminid="MARSIS_ADMIN_1",
                    //        date = DateTime.Now , 
                    //        site="WHITEROSE", 
                    //        deviceid="MARDEV_1", 
                    //        type="AC", 
                    //        location="36.36 , 36.36", 
                    //        devicename="MARSISBILISIM_DEVICE_1" }
                    //    }
                },
                  new Admin
                  {
                      _id = "MARSIS_ADMIN_2",
                      name = "Recep",
                      surname = "Cengiz",
                      username = "recepcengiz",
                      password = "1234",
                      adminid = "recepcengiz",
                      mail = "recepcengiz@gmail.com",
                      site = "MAR-SİS BİLİSİM",
                      tel = "0555 XXX YY ZZ",
                  }

                );





        }
    }
}
