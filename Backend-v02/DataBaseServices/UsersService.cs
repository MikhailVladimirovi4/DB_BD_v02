using Backend_v02.DataBaseCore.Abstractions;
using Backend_v02.DataBaseCore.Models;

namespace Backend_v02.DataBaseServices
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _usersRepository.Get();
        }

        public async Task<Guid> CreateUser(User user, int level)
        {
            return await _usersRepository.Create(user, level);
        }

        public async Task<Guid> UpdateUser(Guid id, string login, string password, int level)
        {
            return await _usersRepository.Update(id, login, password, level);
        }

        public async Task<Guid> DeleteUser(Guid id)
        {
            return await (_usersRepository.Delete(id));
        }
    }
}
