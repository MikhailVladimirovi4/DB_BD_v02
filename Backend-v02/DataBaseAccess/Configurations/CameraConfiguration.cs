using Backend_v02.DataBaseAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Backend_v02.DataBaseAccess.Configurations
{
    public class CameraConfiguration : IEntityTypeConfiguration<CameraEntity>
    {
        public void Configure(EntityTypeBuilder<CameraEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Vendor)
                .IsRequired();

            builder.Property(b => b.Name)
                .IsRequired();

            builder.Property(b => b.Rtsp)
                .IsRequired();
        }
    }
}
