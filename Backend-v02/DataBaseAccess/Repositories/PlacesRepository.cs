using Backend_v02.DataBaseAccess.Entities;
using Backend_v02.DataBaseCore.Abstractions;
using Backend_v02.DataBaseCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_v02.DataBaseAccess.Repositories
{
    public class PlacesRepository : IPlacesRepository
    {
        private readonly DataBaseDbContext _context;

        public PlacesRepository(DataBaseDbContext context)
        {
            _context = context;
        }

        public async Task<List<Place>> Get()
        {
            var placeEntities = await _context.Places
                .AsNoTracking()
                .ToListAsync();

            var places = placeEntities
                .Select(b => Place.Create(b.Id, b.City, b.Address, b.Ip, b.Escort, b.Device).Place)
                .ToList();

            return places;
        }

        public async Task<Guid> Create(Place door)
        {
            PlaceEntity doorEntity = new PlaceEntity
            {
                Id = door.Id,
                City = door.City,
                Address = door.Address,
                Ip = door.Ip,
                Escort = door.Escort,
                Device = door.Device
            };

            await _context.Places.AddAsync(doorEntity);
            await _context.SaveChangesAsync();

            return doorEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string city, string address, string ip, string escort, string device)
        {
            await _context.Places
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.City, b => city)
                .SetProperty(b => b.Address, b => address)
                .SetProperty(b => b.Ip, b => ip)
                .SetProperty(b => b.Escort, b => escort)
                .SetProperty(b => b.Device, b => device));

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Places
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            await _context.SaveChangesAsync();

            return id;
        }
    }
}
