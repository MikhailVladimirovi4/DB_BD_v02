namespace Backend_v02.DataBaseCore.Models
{
    public class Domofon
    {
        const int MAX_DOMOFON_VENDOR_LENGTH = 20;
        const int MAX_DOMOFON_NAME_LENGTH = 20;

        public Guid Id { get; }
        public string Vendor { get; } = string.Empty;
        public string Name { get; } = string.Empty;
        public string ApiOpenDoor { get; } = string.Empty;
        public string ApiCloseDoor { get; } = string.Empty;
        public string ApiOpenForTime { get; } = string.Empty;
        public string ApiStatusDoor { get; } = string.Empty;

        private Domofon(Guid id, string vendor, string name, string apiOpenDoor, string apiCloseDoor, string apiOpenForTime, string apiStatusDoor)
        {
            Id = id;
            Vendor = vendor;
            Name = name;
            ApiOpenDoor = apiOpenDoor;
            ApiCloseDoor = apiCloseDoor;
            ApiOpenForTime = apiOpenForTime;
            ApiStatusDoor = apiStatusDoor;
        }

        public static Domofon Create(Guid id, string vendor, string name, string apiOpenDoor, string apiCloseDoor, string apiOpenForTime, string apiStatusDoor)
        {
            var domofon = new Domofon(id, vendor, name, apiOpenDoor, apiCloseDoor, apiOpenForTime, apiStatusDoor);

            return (domofon);
        }
    }
}
