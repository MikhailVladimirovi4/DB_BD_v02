using Backend_v02.DataBaseCore.Abstractions;
using Backend_v02.DataBaseCore.Models;

namespace Backend_v02.DataBaseServices
{
    public class DoorsService : IDoorsService
    {
        private readonly IDoorsRepository _doorsRepository;

        public DoorsService(IDoorsRepository doorsRepository)
        {
            _doorsRepository = doorsRepository;
        }

        public async Task<List<Door>> GetAllDoors()
        {
            return await _doorsRepository.Get();
        }

        public async Task<Guid> CreateDoor(Door door)
        {
            return await _doorsRepository.Create(door);
        }

        public async void CreateDoors(Door[] door)
        {
            foreach (Door d in door)
            {
                await CreateDoor(d);
            }
        }

        public async Task<Guid> UpdateDoor(Guid id, string city, string street, string house, int number, string ip, string escort, string device)
        {
            return await _doorsRepository.Update(id, city, street, house, number, ip, escort, device);
        }

        public async Task<Guid> DeleteDoor(Guid id)
        {
            return await (_doorsRepository.Delete(id));
        }
    }
}
