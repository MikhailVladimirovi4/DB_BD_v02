namespace Backend_v02.DataBaseAccess.Entities
{
    public class UserEntity
    {
        private Dictionary<string, string> _data = new Dictionary<string, string>();

        public Guid Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Level { get; set; }
    }
}
