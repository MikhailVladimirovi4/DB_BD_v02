using Backend_v02.Contracts;
using Backend_v02.DataBaseAccess;
using Backend_v02.DataBaseCore.Models;

namespace Backend_v02.DataBaseCore.Abstractions
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponse> GetLogin(LoginRequest loginRequest);
        Task<LocalUser> Rigester(RegistrationRequest registrationRequest);
    }
}
