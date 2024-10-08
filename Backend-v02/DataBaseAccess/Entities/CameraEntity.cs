namespace Backend_v02.DataBaseAccess.Entities
{
    public class CameraEntity
    {
        public Guid Id { get; set; }
        public string Vendor { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Rtsp { get; set; } = string.Empty;
    }
}
