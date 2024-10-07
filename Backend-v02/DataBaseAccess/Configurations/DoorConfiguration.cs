using Backend_v02.DataBaseAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_v02.DataBaseAccess.Configurations
{
    public class DoorConfiguration : IEntityTypeConfiguration<DoorEntity>
    {
        public void Configure(EntityTypeBuilder<DoorEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.City)
                .IsRequired();

            builder.Property(b => b.Street)
                .IsRequired();

            builder.Property(b => b.House)
                .IsRequired();

            builder.Property(b => b.Number)
                .IsRequired();

            builder.Property(b => b.Ip)
                .IsRequired();

            builder.Property(b => b.Escort)
                .IsRequired();

            builder.Property(b => b.Device)
                .IsRequired();
        }
    }
}
