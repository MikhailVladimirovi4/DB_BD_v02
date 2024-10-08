using Backend_v02.DataBaseCore.Models;

namespace Backend_v02.DataBaseCore.Abstractions
{
    public interface IDoorsService
    {
        Task<Guid> CreateDoor(Door door);
        void CreateDoors(Door[] door);
        Task<Guid> DeleteDoor(Guid id);
        Task<List<Door>> GetAllDoors();
        Task<Guid> UpdateDoor(Guid id, string city, string street, string house, int number, string ip, string escort, string device);
    }
}