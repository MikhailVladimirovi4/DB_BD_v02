namespace Backend_v02.DataBaseAccess.Entities
{
    public class DoorEntity
    {
        public Guid Id { get; set; }
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string House { get; set; } = string.Empty;
        public int Number { get; set; }
        public string Ip { get; set; } = string.Empty;
        public string Escort { get; set; } = string.Empty;
        public string Device { get; set; } = string.Empty;
    }
}
