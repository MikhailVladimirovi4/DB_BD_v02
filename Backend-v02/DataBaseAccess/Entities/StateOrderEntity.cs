namespace Backend_v02.DataBaseAccess.Entities
{
    public class StateOrderEntity
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Year { get; set; }
    }
}
