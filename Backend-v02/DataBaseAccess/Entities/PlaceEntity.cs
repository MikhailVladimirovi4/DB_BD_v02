namespace Backend_v02.DataBaseAccess.Entities
{
    public class PlaceEntity
    {
        public Guid Id { get; set; }
        public string City { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Ip { get; set; } = string.Empty;
        public string Escort { get; set; } = string.Empty;
        public string Device { get; set; } = string.Empty;
    }
}
