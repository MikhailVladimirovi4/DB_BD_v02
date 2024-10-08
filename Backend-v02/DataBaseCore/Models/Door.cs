namespace Backend_v02.DataBaseCore.Models
{
    public class Door
    {
        public Guid Id { get; }
        public string City { get; }
        public string Street { get; }
        public string House { get; }
        public int Number { get; }
        public string Ip { get; }
        public string Escort { get; }
        public string Device { get; }

        private Door(Guid id, string city, string street, string house, int number, string ip, string escort, string device)
        {
            Id = id;
            City = city;
            Street = street;
            House = house;
            Number = number;
            Ip = ip;
            Escort = escort;
            Device = device;
        }

        public static Door Create(Guid id, string city, string street, string house, int number, string ip, string escort, string device)
        {
            var door = new Door(id, city, street, house, number, ip, escort, device);

            return (door);
        }
    }
}
