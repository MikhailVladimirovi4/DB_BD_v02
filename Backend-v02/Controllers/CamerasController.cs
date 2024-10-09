using Backend_v02.Contracts;
using Backend_v02.DataBaseCore.Abstractions;
using Backend_v02.DataBaseCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend_v02.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class CamerasController : ControllerBase
    {
        private readonly ICamerasService _camerasService;

        public CamerasController(ICamerasService camerasService)
        {
            _camerasService = camerasService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CamerasResponse>>> GetCameras()
        {
            var camera = await _camerasService.GetAllCameras();

            var response = camera.Select(b => new CamerasResponse(b.Id, b.Vendor,b.Name,b.Rtsp));

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
