using Backend_v02.DataBaseCore.Models;

namespace Backend_v02.DataBaseCore.Abstractions
{
    public interface ICamerasService
    {
        Task<Guid> CreateCamera(Camera camera);
        Task<Guid> DeleteCamera(Guid id);
        Task<List<Camera>> GetAllCameras();
        Task<Guid> UpdateCamera(Guid id, string vendor, string name, string rtsp);
    }
}