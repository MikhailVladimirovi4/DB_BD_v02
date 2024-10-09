namespace Backend_v02.Contracts
{
    public record PlacesRequest(
        string City,
        string Address,
        string Ip,
        string Escort,
        string Device);
}
