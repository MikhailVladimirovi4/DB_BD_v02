using Backend_v02.Contracts;
using Backend_v02.DataBaseCore.Abstractions;
using Backend_v02.DataBaseCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend_v02.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class StateOrdersController : ControllerBase
    {
        private readonly IStateOrdersService _stateOrdersService;

        public StateOrdersController(IStateOrdersService stateOrdersService)
        {
            _stateOrdersService = stateOrdersService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StateOrdersResponse>>> GetStateOrders()
        {
            var stateOrder = await _stateOrdersService.GetAllStateOrders();

            var response = stateOrder.Select(b => new StateOrdersResponse(b.Id, b.Number, b.Name, b.Year));

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
        public async Task<ActionResult<Guid>> UpdateStateOrder(Guid id,int number, string name, int year)
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
