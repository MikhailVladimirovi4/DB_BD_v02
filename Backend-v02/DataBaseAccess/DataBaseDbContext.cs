using Backend_v02.DataBaseAccess.Entities;
using Microsoft.EntityFrameworkCore;


namespace Backend_v02.DataBaseAccess
{
    public class DataBaseDbContext : DbContext
    {
        public DataBaseDbContext(DbContextOptions<DataBaseDbContext> options)
            : base(options){}

        public DbSet<CameraEntity> Cameras { get; set; }
        public DbSet<PlaceEntity> Places { get; set; }
        public DbSet<StateOrderEntity> StateOrders { get; set; }
        public DbSet<UserEntity> Users { get; set; }
    }
}
