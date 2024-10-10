using Backend_v02.Contracts;
using Backend_v02.DataBaseAccess;
using Backend_v02.DataBaseCore.Abstractions;
using Backend_v02.DataBaseCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_v02.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlacesController : ControllerBase
    {
        private readonly IPlacesService _placesService;
        private readonly DataBaseDbContext _dataBaseDbContext;

        public PlacesController(IPlacesService placesService, DataBaseDbContext dataBaseDbContext)
        {
            _placesService = placesService;
            _dataBaseDbContext = dataBaseDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<PlacesResponse>>> GetPlaces(string? search, string? sortItem, string? sortOrder)
        {
            var placesQuery = _dataBaseDbContext.Places.Where(n => string.IsNullOrWhiteSpace(search) || n.Address.ToLower().Contains(search.ToLower()));

            switch (sortItem?.ToLower())
            {
                case "vendor":
                    if (sortOrder == "desc")
                        placesQuery = placesQuery.OrderByDescending(n => n.City);
                    else
                        placesQuery = placesQuery.OrderBy(n => n.City);
                    break;
                case "name":
                    if (sortOrder == "desc")
                        placesQuery = placesQuery.OrderByDescending(n => n.Address);
                    else
                        placesQuery = placesQuery.OrderBy(n => n.Address);
                    break;
                case "ip":
                    if (sortOrder == "desc")
                        placesQuery = placesQuery.OrderByDescending(n => n.Ip);
                    else
                        placesQuery = placesQuery.OrderBy(n => n.Ip);
                    break;
                case "escort":
                    if (sortOrder == "desk")
                        placesQuery = placesQuery.OrderByDescending(n => n.Escort);
                    else
                        placesQuery = placesQuery.OrderBy(n => n.Escort);
                    break;
                case "devise":
                    if (sortOrder == "desk")
                        placesQuery = placesQuery.OrderByDescending(n => n.Device);
                    else
                        placesQuery = placesQuery.OrderBy(n => n.Device);
                    break;
                default:
                    if (sortOrder == "desk")
                        placesQuery = placesQuery.OrderByDescending(n => n.Id);
                    else
                        placesQuery = placesQuery.OrderBy(n => n.Id);
                    break;
            }

            var response = await placesQuery.Select(b => new PlacesResponse(b.Id, b.City,b.Address,b.Ip,b.Escort,b.Device)).ToListAsync();

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreatePlace([FromBody] PlacesRequest request)
        {
            var (place, error) = Place.Create(
                Guid.NewGuid(),
                request.City,
                request.Address,
                request.Ip,
                request.Escort,
                request.Device);

            if (!string.IsNullOrEmpty(error))
                return BadRequest(error);

            var placeId = await _placesService.CreatePlace(place);

            return Ok(placeId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdatePlace(Guid id, string city, string address, string ip, string escort, string device)
        {
            var placeId = await _placesService.UpdatePlace(id, city, address, ip, escort, device);

            return Ok(placeId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeletePlace(Guid id)
        {
            return Ok(await _placesService.DeletePlace(id));
        }
    }
}
