using Backend_v02.DataBaseCore.Models;

namespace Backend_v02.DataBaseCore.Abstractions
{
    public interface IDoorsRepository
    {
        Task<Guid> Create(Door door);
        Task<Guid> Delete(Guid id);
        Task<List<Door>> Get();
        Task<Guid> Update(Guid id, string city, string street, string house, int number, string ip, string escort, string device);
    }
}