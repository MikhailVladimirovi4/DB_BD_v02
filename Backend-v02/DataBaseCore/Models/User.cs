namespace Backend_v02.DataBaseCore.Models
{
    public class User
    {
        public static int USER_LEVEL_VIEWER = 0;
        public static int USER_LEVEL_OPERATOR = 10;
        public static int USER_LEVEL_ADMIN = 100;

        private Dictionary<string, string> _data = new Dictionary<string, string>();

        public Guid Id { get; }
        public string Login { get; }
        public int Level { get; }

        private User(Guid id, string login, string password, int level)
        {
            Id = id;
            Login = login;
            _data.Add(login, password); // Вставить логику шифра
            Level = level;
        }

        public static User Create(Guid id, string login, string password, int level)
        {
            var user = new User(id, login, password, level);

            return (user);
        }

        public string GetPassword(int level, string login)
        {
            if (level == USER_LEVEL_ADMIN)
                return _data[login];
            else
                return string.Empty;
        }
    }
}
