using Backend_v02.Contracts;
using Backend_v02.DataBaseCore.Abstractions;
using Backend_v02.DataBaseCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend_v02.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlacesController : ControllerBase
    {
        private readonly IPlacesService _placesService;

        public PlacesController(IPlacesService placesService)
        {
            _placesService = placesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PlacesResponse>>> GetPlace()
        {
            var places = await _placesService.GetAllPlaces();

            var response = places.Select(b => new PlacesResponse(b.Id, b.City, b.Address, b.Ip, b.Escort, b.Device));

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
