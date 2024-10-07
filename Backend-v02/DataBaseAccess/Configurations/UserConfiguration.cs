using Backend_v02.DataBaseAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_v02.DataBaseAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Login)
                .IsRequired();

            builder.Property(b => b.Level).
                IsRequired();

            builder.Property(b => b.Password)
                .IsRequired();
        }
    }
}
