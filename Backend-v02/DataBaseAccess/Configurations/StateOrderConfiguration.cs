using Backend_v02.DataBaseAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_v02.DataBaseAccess.Configurations
{
    public class StateOrderConfiguration : IEntityTypeConfiguration<StateOrderEntity>
    {
        public void Configure(EntityTypeBuilder<StateOrderEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Number)
                .IsRequired();

            builder.Property(b => b.Name).
                IsRequired();

            builder.Property(b => b.Year)
                .IsRequired();
        }
    }
}
