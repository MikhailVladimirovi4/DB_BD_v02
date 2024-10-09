using Backend_v02.Contracts;
using Backend_v02.DataBaseCore.Abstractions;
using Backend_v02.DataBaseCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend_v02.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsersResponse>>> GetUsers()
        {
            var user = await _usersService.GetAllUsers();
            var response = user.Select(b => new UsersResponse(b.Id, b.Login, b.Level));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateUser([FromBody] UsersRequest request)
        {
            var user = User.
                
                
                (
                Guid.NewGuid(),
                request.Login,
                request.Password,
                request.Level);

            var userId = await _usersService.CreateUser(user);

            return Ok(userId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateUser(Guid id, string login, string password, int level)
        {
            var userId = await _usersService.UpdateUser(id, login, password, level);

            return Ok(userId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteUser(Guid id)
        {
            return Ok(await _usersService.DeleteUser(id));
        }
    }
}
