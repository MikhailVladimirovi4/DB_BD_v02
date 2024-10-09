namespace Backend_v02.Contracts
{
    public record CamerasResponse(
        Guid Id,
        string Vendor,
        string Name,
        string Rtsp);
}
