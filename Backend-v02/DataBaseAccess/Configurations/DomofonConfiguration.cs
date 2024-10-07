using Backend_v02.DataBaseAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Backend_v02.DataBaseAccess.Configurations
{
    public class DomofonConfiguration : IEntityTypeConfiguration<DomofonEntity>
    {
        public void Configure(EntityTypeBuilder<DomofonEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Vendor)
                .IsRequired();

            builder.Property(b => b.Name)
                .IsRequired();

            builder.Property(b => b.ApiOpenDoor)
                .IsRequired();

            builder.Property(b => b.ApiCloseDoor)
                .IsRequired();

            builder.Property(b => b.ApiOpenForTime)
                .IsRequired();

            builder.Property(b => b.ApiStatusDoor)
                .IsRequired();
        }
    }
}
