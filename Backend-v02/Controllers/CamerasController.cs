using Backend_v02.Contracts;
using Backend_v02.DataBaseAccess;
using Backend_v02.DataBaseCore.Abstractions;
using Backend_v02.DataBaseCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_v02.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class CamerasController : ControllerBase
    {
        private readonly ICamerasService _camerasService;
        private readonly DataBaseDbContext _dataBaseDbContext;

        public CamerasController(ICamerasService camerasService, DataBaseDbContext dataBaseDbContext)
        {
            _camerasService = camerasService;
            _dataBaseDbContext = dataBaseDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<CamerasResponse>>> GetCameras(string? keyParametr, string search, string? sortOrder)
        {

            var camerasQuery = _dataBaseDbContext.Cameras.Where(n => string.IsNullOrWhiteSpace(search) || n.Name.ToLower().Contains(search.ToLower()));

            switch (keyParametr)
            {
                case "vendor":
                    if (sortOrder == "desc")
                        camerasQuery = camerasQuery.OrderByDescending(n => n.Vendor);
                    else
                        camerasQuery = camerasQuery.OrderBy(n => n.Vendor);
                    break;

                case "name":
                    if (sortOrder == "desc")
                        camerasQuery = camerasQuery.OrderByDescending(n => n.Name);
                    else
                        camerasQuery = camerasQuery.OrderBy(n => n.Name);
                    break;

                default:
                    if (sortOrder == "desc")
                        camerasQuery = camerasQuery.OrderByDescending(n => n.Id);
                    else
                        camerasQuery = camerasQuery.OrderBy(n => n.Id);
                    break;
            }

            var response = await camerasQuery.Select(b => new CamerasResponse(b.Id, b.Vendor, b.Name, b.Rtsp)).ToListAsync();

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateCamera([FromBody] CamerasRequest request)
        {
            var camera = Camera.Create(
                Guid.NewGuid(),
                request.Vendor,
                request.Name,
                request.Rtsp);

            var cameraId = await _camerasService.CreateCamera(camera);

            return Ok(cameraId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateCamera(Guid id, string vendor, string name, string rtsp)
        {
            var cameraId = await _camerasService.UpdateCamera(id, vendor, name, rtsp);

            return Ok(cameraId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteCamera(Guid id)
        {
            return Ok(await _camerasService.DeleteCamera(id));
        }
    }
}
