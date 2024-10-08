namespace Backend_v02.Contracts
{
    public record UsersResponse(
        Guid Id,
        string Login,
        int Level);
}
