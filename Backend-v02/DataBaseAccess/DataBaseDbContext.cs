using Microsoft.EntityFrameworkCore;

namespace Backend_v02.DataBaseAccess
{
    public class DataBaseDbContext : DbContext
    {
        public DataBaseDbContext(DbContextOptions<DataBaseDbContext> options)
            : base(options)
        {

        }
    }
}
