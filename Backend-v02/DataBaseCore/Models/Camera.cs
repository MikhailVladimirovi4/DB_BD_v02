namespace Backend_v02.DataBaseCore.Models
{
    public class Camera
    {
        const int MAX_CAMERA_VENDOR_LENGTH = 20;
        const int MAX_CAMERA_NAME_LENGTH = 20;

        public Guid Id { get; }
        public string Vendor { get; }
        public string Name { get; }
        public string Rtsp { get; }

        private Camera(Guid id, string vendor, string name, string rtsp)
        {
            Id = id;
            Vendor = vendor;
            Name = name;
            Rtsp = rtsp;
        }

        public static Camera Create(Guid id, string vendor, string name, string rtsp)
        {
            Camera camera = new Camera(id, vendor, name, rtsp);

            return (camera);
        }
    }
}
