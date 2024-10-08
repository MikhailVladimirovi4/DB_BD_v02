using Backend_v02.DataBaseCore.Abstractions;
using Backend_v02.DataBaseCore.Models;

namespace Backend_v02.DataBaseServices
{
    public class CamerasService : ICamerasService
    {
        private readonly ICamerasRepository _camerasRepository;

        public CamerasService(ICamerasRepository camerasRepository)
        {
            _camerasRepository = camerasRepository;
        }

        public async Task<List<Camera>> GetAllCameras()
        {
            return await _camerasRepository.Get();
        }

        public async Task<Guid> CreateCamera(Camera camera)
        {
            return await _camerasRepository.Create(camera);
        }

        public async Task<Guid> UpdateCamera(Guid id, string vendor, string name, string rtsp)
        {
            return await _camerasRepository.Update(id, vendor, name, rtsp);
        }

        public async Task<Guid> DeleteCamera(Guid id)
        {
            return await (_camerasRepository.Delete(id));
        }
    }
}
