using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PowerSarj_2022.Entities.Concrete;

namespace PowerSarj_2022.DataAccess.Concrete.Context.EfContext
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(c => c._id);
            builder.Property(c => c._id).ValueGeneratedOnAdd();

            
            builder.HasIndex(c => c.userid).IsUnique();
            //builder.HasIndex(c => c.username).IsUnique();


            //builder.HasData(
            //    new User
            //    {
            //        _id = System.Guid.NewGuid().ToString(),
            //        balance = 150,
            //        cardid = "554423564523",
            //        date = System.DateTime.Now,
            //        __v = 0,


            //    }

            //    );





        }
    }
}