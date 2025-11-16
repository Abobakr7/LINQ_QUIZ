namespace LINQ_QUIZ.Models
{
    internal class Department
    {
        public readonly static Department IT = new (1, "IT");
        public readonly static Department SERVICE_GROUP = new (2, "ServiceGroups");
        public readonly static Department HR = new (3, "HR");
        public readonly static Department OIL_AND_GAS = new(4, "oil and gas");


        public int Id { get;private set; }
        public string Name { get;private set; }
        public List<User> Users { get;private set; }

        private Department(int id, string name)
        {
            Id = id;
            Name = name;
            Users = new List<User>();
        }
    }
}
