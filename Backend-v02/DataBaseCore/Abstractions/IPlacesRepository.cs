using Backend_v02.DataBaseCore.Models;

namespace Backend_v02.DataBaseCore.Abstractions
{
    public interface IPlacesRepository
    {
        Task<Guid> Create(Place door);
        Task<Guid> Delete(Guid id);
        Task<List<Place>> Get();
        Task<Guid> Update(Guid id, string city, string assress, string ip, string escort, string device);
    }
}