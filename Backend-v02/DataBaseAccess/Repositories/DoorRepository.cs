using Backend_v02.DataBaseAccess.Entities;
using Backend_v02.DataBaseCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_v02.DataBaseAccess.Repositories
{
    public class DoorRepository
    {
        private readonly DataBaseDbContext _context;

        public DoorRepository(DataBaseDbContext context)
        {
            _context = context;
        }

        public async Task<List<Door>> Get()
        {
            var doorEntities = await _context.Doors
                .AsNoTracking()
                .ToListAsync();

            var doors = doorEntities
                .Select(b => Door.Create(b.Id, b.City, b.Street, b.House, b.Number, b.Ip, b.Escort, b.Device))
                .ToList();

            return doors;           
        }
    }
}
