using Backend_v02.DataBaseCore.Models;

namespace Backend_v02.DataBaseCore.Abstractions
{
    public interface IUsersRepository
    {
        Task<Guid> Create(User user, int level);
        Task<Guid> Delete(Guid id);
        Task<List<User>> Get();
        Task<Guid> Update(Guid id, string login, string password, int level);
    }
}