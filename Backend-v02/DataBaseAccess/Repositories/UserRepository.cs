using Backend_v02.Contracts;
using Backend_v02.DataBaseCore.Abstractions;
using Backend_v02.DataBaseCore.Models;

namespace Backend_v02.DataBaseAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseDbContext _dataBaseDbContext;

        public UserRepository(DataBaseDbContext dataBaseDbContext)
        {
            _dataBaseDbContext = dataBaseDbContext;
        }

        public Task<LoginResponse> GetLogin(LoginRequest loginRequest)
        {
            throw new NotImplementedException();
        }

        public bool IsUniqueUser(string username)
        {
            throw new NotImplementedException();
        }

        public Task<LocalUser> Rigester(RegistrationRequest registrationRequest)
        {
            throw new NotImplementedException();
        }
    }
}
