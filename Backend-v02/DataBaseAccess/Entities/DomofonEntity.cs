namespace Backend_v02.DataBaseAccess.Entities
{
    public class DomofonEntity
    {
        public Guid Id { get; set; }
        public string Vendor { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ApiOpenDoor { get; set; } = string.Empty;
        public string ApiCloseDoor { get; set; } = string.Empty;
        public string ApiOpenForTime { get; set; } = string.Empty;
        public string ApiStatusDoor { get; set; } = string.Empty;
    }
}
