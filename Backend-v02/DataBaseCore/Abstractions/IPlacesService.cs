using Backend_v02.DataBaseCore.Models;

namespace Backend_v02.DataBaseCore.Abstractions
{
    public interface IPlacesService
    {
        Task<Guid> CreatePlace(Place place);
        void CreatePlaces(Place[] place);
        Task<Guid> DeletePlace(Guid id);
        Task<List<Place>> GetAllPlaces();
        Task<Guid> UpdatePlace(Guid id, string city, string address, string ip, string escort, string device);
    }
}