using Backend_v02.DataBaseCore.Models;

namespace Backend_v02.DataBaseCore.Abstractions
{
    public interface IStateOrdersService
    {
        Task<Guid> CreateStateOrder(StateOrder stateOrder);
        Task<Guid> DeleteStateOrder(Guid id);
        Task<List<StateOrder>> GetAllStateOrders();
        Task<Guid> UpdateStateOrder(Guid id, int number, string name, int year);
    }
}