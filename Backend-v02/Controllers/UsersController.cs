using Backend_v02.Contracts;
using Backend_v02.DataBaseCore.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Backend_v02.DataBaseCore.Models;

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
            var user =

            await _usersService.CreateUser(user);

            return Ok(user);
        }
    }
}
