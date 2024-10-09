using Backend_v02.DataBaseCore.Abstractions;
using Backend_v02.DataBaseCore.Models;

namespace Backend_v02.DataBaseServices
{
    public class PlacesService : IPlacesService
    {
        private readonly IPlacesRepository _placesRepository;

        public PlacesService(IPlacesRepository placesRepository)
        {
            _placesRepository = placesRepository;
        }

        public async Task<List<Place>> GetAllPlaces()
        {
            return await _placesRepository.Get();
        }

        public async Task<Guid> CreatePlace(Place door)
        {
            return await _placesRepository.Create(door);
        }

        public async void CreatePlaces(Place[] places)
        {
            foreach (Place place in places)
            {
                await CreatePlace(place);
            }
        }

        public async Task<Guid> UpdatePlace(Guid id, string city, string address, string ip, string escort, string device)
        {
            return await _placesRepository.Update(id, city, address, ip, escort, device);
        }

        public async Task<Guid> DeletePlace(Guid id)
        {
            return await (_placesRepository.Delete(id));
        }
    }
}
