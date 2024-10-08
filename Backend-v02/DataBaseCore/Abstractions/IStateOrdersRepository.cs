using Backend_v02.DataBaseCore.Models;

namespace Backend_v02.DataBaseCore.Abstractions
{
    public interface IStateOrdersRepository
    {
        Task<Guid> Create(StateOrder stateOrder);
        Task<Guid> Delete(Guid id);
        Task<List<StateOrder>> Get();
        Task<Guid> Update(Guid id, int number, string name, int year);
    }
}