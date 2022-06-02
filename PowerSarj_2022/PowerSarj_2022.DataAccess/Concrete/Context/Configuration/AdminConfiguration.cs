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

            //builder.HasData(
            //    new Admin
            //    {
            //        Id = 1,
            //        Name = "Recep",
            //        Surname = "Cengiz",
            //    },

            //    new Admin
            //    {
            //        Id = 2,
            //        Name = "Ahmet",
            //        Surname = "Yılmaz",
            //    }

            //    );





        }
    }
}
