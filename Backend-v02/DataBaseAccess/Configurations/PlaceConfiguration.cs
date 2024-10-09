using Backend_v02.DataBaseAccess.Entities;
using Backend_v02.DataBaseCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_v02.DataBaseAccess.Configurations
{
    public class PlaceConfiguration : IEntityTypeConfiguration<PlaceEntity>
    {
        public void Configure(EntityTypeBuilder<PlaceEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.City)
                .IsRequired();

            builder.Property(b => b.Address)
                .HasMaxLength(Place.MAX_ADDRESS_LENGTH)
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
