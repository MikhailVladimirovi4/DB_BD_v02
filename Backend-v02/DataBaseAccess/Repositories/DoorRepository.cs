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

        public async Task<Guid> Create(Door door)
        {
            DoorEntity doorEntity = new DoorEntity
            {
                Id = door.Id,
                City = door.City,
                Street = door.Street,
                House = door.House,
                Number = door.Number,
                Ip = door.Ip,
                Escort = door.Escort,
                Device = door.Device
            };

            await _context.Doors.AddAsync(doorEntity);
            await _context.SaveChangesAsync();

            return doorEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string city, string street, string house, int number, string ip, string escort, string device)
        {
            await _context.Doors
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.City, b => city)
                .SetProperty(b => b.Street, b => street)
                .SetProperty(b => b.House, b => house)
                .SetProperty(b => b.Number, b => number)
                .SetProperty(b => b.Ip, b => ip)
                .SetProperty(b => b.Escort, b => escort)
                .SetProperty(b => b.Device, b => device));

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Doors
                .Where (b => b.Id == id)
                .ExecuteDeleteAsync();

            await _context.SaveChangesAsync();

            return id;
        }
    }
}
