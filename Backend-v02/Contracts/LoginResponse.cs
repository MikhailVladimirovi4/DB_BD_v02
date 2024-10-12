using Backend_v02.DataBaseCore.Models;

namespace Backend_v02.Contracts
{
    public class LoginResponse
    {
        public LocalUser User { get; set; }
        public string Token { get; set; }
    }
}
