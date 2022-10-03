namespace Isu.Entities
{
    public class Student
    {
        private static int id = 100000;

        private string _name;
        private int _id;
        private Group _group;
        public Student(string name)
        {
            _name = name;
            _id = id++;
        }

        public int ID => _id;
        public string Name => _name;
        public Group Group => _group;

        public void AddGroupToStudent(Group group)
        {
            _group = group;
        }
    }
}