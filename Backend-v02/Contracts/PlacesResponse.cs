namespace Backend_v02.Contracts
{
    public record PlacesResponse(
        Guid Id,
        string City,
        string Address,
        string Ip,
        string Escort,
        string Device);
}
