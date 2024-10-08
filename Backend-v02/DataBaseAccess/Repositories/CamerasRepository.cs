using Backend_v02.DataBaseAccess.Entities;
using Backend_v02.DataBaseCore.Abstractions;
using Backend_v02.DataBaseCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_v02.DataBaseAccess.Repositories
{
    public class CamerasRepository : ICamerasRepository
    {
        private readonly DataBaseDbContext _context;

        public CamerasRepository(DataBaseDbContext context)
        {
            _context = context;
        }

        public async Task<List<Camera>> Get()
        {
            var cameraEntities = await _context.Cameras
                .AsNoTracking()
                .ToListAsync();

            var cameras = cameraEntities
                .Select(b => Camera.Create(b.Id, b.Vendor, b.Name, b.Rtsp))
                .ToList();

            return cameras;
        }

        public async Task<Guid> Create(Camera camera)
        {
            CameraEntity cameraEntity = new CameraEntity
            {
                Id = camera.Id,
                Vendor = camera.Vendor,
                Name = camera.Name,
                Rtsp = camera.Rtsp,
            };

            await _context.Cameras.AddAsync(cameraEntity);
            await _context.SaveChangesAsync();

            return cameraEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string vendor, string name, string rtsp)
        {
            await _context.Cameras
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Vendor, b => vendor)
                .SetProperty(b => b.Name, b => name)
                .SetProperty(b => b.Rtsp, b => rtsp));

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Cameras
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            await _context.SaveChangesAsync();

            return id;
        }
    }
}
