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

    public class StateOrdersController : ControllerBase
    {
        private readonly IStateOrdersService _stateOrdersService;
        private readonly DataBaseDbContext _dataBaseDbContext;

        public StateOrdersController(IStateOrdersService stateOrdersService, DataBaseDbContext dataBaseDbContext)
        {
            _stateOrdersService = stateOrdersService;
            _dataBaseDbContext = dataBaseDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<StateOrdersResponse>>> GetStateOrders(string? search, string? sortItem, string? sortOrder)
        {
            var stateOrdersQuery = _dataBaseDbContext.StateOrders
                .Where(n => string.IsNullOrWhiteSpace(search) || n.Name.ToLower().Contains(search.ToLower()));

            switch (sortItem?.ToLower())
            {
                case "vendor":
                    if (sortOrder == "desc")
                        stateOrdersQuery = stateOrdersQuery.OrderByDescending(n => n.Number);
                    else
                        stateOrdersQuery = stateOrdersQuery.OrderBy(n => n.Number);
                    break;
                case "name":
                    if (sortOrder == "desc")
                        stateOrdersQuery = stateOrdersQuery.OrderByDescending(n => n.Name);
                    else
                        stateOrdersQuery = stateOrdersQuery.OrderBy(n => n.Name);
                    break;
                default:
                    if (sortOrder == "desc")
                        stateOrdersQuery = stateOrdersQuery.OrderByDescending(n => n.Id);
                    else
                        stateOrdersQuery = stateOrdersQuery.OrderBy(n => n.Id);
                    break;
            }

            var response = await stateOrdersQuery.Select(b => new StateOrdersResponse(b.Id, b.Number, b.Name, b.Year)).ToListAsync();

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateStateOrder([FromBody] StateOrdersRequest request)
        {
            var stateOrder = StateOrder.Create(
                Guid.NewGuid(),
                request.Number,
                request.Name,
                request.Year);
            ;


            var stateOrderId = await _stateOrdersService.CreateStateOrder(stateOrder);

            return Ok(stateOrderId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateStateOrder(Guid id, int number, string name, int year)
        {
            var stateOrderId = await _stateOrdersService.UpdateStateOrder(id, number, name, year);

            return Ok(stateOrderId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteStateOrder(Guid id)
        {
            return Ok(await _stateOrdersService.DeleteStateOrder(id));
        }
    }
}
