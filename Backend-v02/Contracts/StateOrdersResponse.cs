namespace Backend_v02.Contracts
{
    public record StateOrdersResponse(
        Guid Id,
        int Number,
        string Name,
        int Year);
}
