using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PowerSarj_2022.Entities.Concrete;

namespace PowerSarj_2022.DataAccess.Concrete.Context.EfContext
{
    public class FillsConfiguration : IEntityTypeConfiguration<Fill>
    {
        public void Configure(EntityTypeBuilder<Fill> builder)
        {
            builder.HasKey(c => c._id);
            builder.Property(c => c._id).ValueGeneratedOnAdd();


        }
    }
}