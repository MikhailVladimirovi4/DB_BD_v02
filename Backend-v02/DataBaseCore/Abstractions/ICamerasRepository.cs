using Backend_v02.DataBaseCore.Models;

namespace Backend_v02.DataBaseCore.Abstractions
{
    public interface ICamerasRepository
    {
        Task<Guid> Create(Camera camera);
        Task<Guid> Delete(Guid id);
        Task<List<Camera>> Get();
        Task<Guid> Update(Guid id, string vendor, string name, string rtsp);
    }
}