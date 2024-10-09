namespace Backend_v02.DataBaseCore.Models
{
    public class Place
    {
        public const int MAX_ADDRESS_LENGTH = 100;

        public Guid Id { get; }
        public string City { get; }
        public string Address { get; }
        public string Ip { get; }
        public string Escort { get; }
        public string Device { get; }

        private Place(Guid id, string city, string address, string ip, string escort, string device)
        {
            Id = id;
            City = city;
            Address = address;
            Ip = ip;
            Escort = escort;
            Device = device;
        }

        public static (Place Place, string Error) Create(Guid id, string city, string address, string ip, string escort, string device)
        {
            string error = string.Empty;
            var place = new Place(id, city, address, ip, escort, device);

            if (string.IsNullOrEmpty(error) || address.Length > MAX_ADDRESS_LENGTH)
            {
                error = "No address for the place or it.s long";
            }

            return (place, error);
        }
    }
}
