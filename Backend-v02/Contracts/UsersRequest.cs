namespace Backend_v02.Contracts
{
   public record UsersRequest(
    string Login,
    string Password,
    int Level);
}
