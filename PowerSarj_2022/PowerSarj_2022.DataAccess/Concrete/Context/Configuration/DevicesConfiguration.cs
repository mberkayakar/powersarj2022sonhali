using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PowerSarj_2022.Entities.Concrete;
using System;

namespace PowerSarj_2022.DataAccess.Concrete.Context.EfContext
{
    public class DevicesConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasKey(c => c._id);
            builder.Property(c => c._id).ValueGeneratedOnAdd();

            builder.HasData(
                    new Device
                    {
                        _id = "MARDEV_1",
                        adminid = "MARSIS_ADMIN_1",
                        date = DateTime.Now,
                        site = "WHITEROSE",
                        deviceid = "MARDEV_1",
                        type = "AC",
                        location = "36.36 , 36.36",
                        devicename = "MARSISBILISIM_DEVICE_1"
                    },
                      new Device
                      {
                          _id = "MARDEV_2",
                          adminid = "MARSIS_ADMIN_2",
                          date = DateTime.Now,
                          site = "MAR-SİS BİLİSİM",
                          deviceid = "MARDEV_2",
                          type = "AC",
                          location = "36.37 , 36.37",
                          devicename = "MARSISBILISIM_DEVICE_2"
                      },
                        new Device
                        {
                            _id = "MARDEV_3",
                            adminid = "MARSIS_ADMIN_2",
                            date = DateTime.Now,
                            site = "MAR-SİS BİLİSİM",
                            deviceid = "MARDEV_3",
                            type = "DC",
                            location = "36.37 , 36.37",
                            devicename = "MARSISBILISIM_DEVICE_3"
                        }
                );






        }
}
}