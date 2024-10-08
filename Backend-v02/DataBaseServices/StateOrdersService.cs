using Backend_v02.DataBaseCore.Abstractions;
using Backend_v02.DataBaseCore.Models;

namespace Backend_v02.DataBaseServices
{
    public class StateOrdersService : IStateOrdersService
    {
        private readonly IStateOrdersRepository _stateOrdersRepository;

        public StateOrdersService(IStateOrdersRepository stateOrdersRepository)
        {
            _stateOrdersRepository = stateOrdersRepository;
        }

        public async Task<List<StateOrder>> GetAllStateOrders()
        {
            return await _stateOrdersRepository.Get();
        }

        public async Task<Guid> CreateStateOrder(StateOrder stateOrder)
        {
            return await _stateOrdersRepository.Create(stateOrder);
        }

        public async Task<Guid> UpdateStateOrder(Guid id, int number, string name, int year)
        {
            return await _stateOrdersRepository.Update(id, number, name, year);
        }

        public async Task<Guid> DeleteStateOrder(Guid id)
        {
            return await (_stateOrdersRepository.Delete(id));
        }
    }
}
