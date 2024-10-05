namespace Backend_v02.DataBaseCore.Models
{
    public class StateOrder
    {
        public Guid Id { get; }
        public int Number { get; }
        public string Name { get; } = string.Empty;
        public int Year { get; }

        private StateOrder(Guid id, int number, string name, int year)
        {
            Id = id;
            Number = number;
            Name = name;
            Year = year;
        }
        public static StateOrder Create(Guid id, int number, string name, int year)
        {
            var stateOrder = new StateOrder(id, number, name, year);

            return (stateOrder);
        }
    }
}
