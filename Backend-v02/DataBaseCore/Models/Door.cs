using System.Reflection.Emit;
using System.Xml.Linq;

namespace Backend_v02.DataBaseCore.Models
{
    public class Door
    {
        public Guid Id { get; }
        public string City { get; } = string.Empty;
        public string Street { get; } = string.Empty;
        public string House { get; } = string.Empty;
        public int Number { get; }
        public string Ip { get; } = string.Empty;
        public string Escort { get; } = string.Empty;
        public string Device { get; } = string.Empty;

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
