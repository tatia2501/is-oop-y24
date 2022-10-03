namespace IsuExtra.Entities
{
    public class Lesson
    {
        private string _name;
        private string _day;
        private string _time;
        private string _teacher;
        private int _classroom;
        public Lesson(string name, string day, string time, string teacher, int classroom)
        {
            _name = name;
            _day = day;
            _time = time;
            _teacher = teacher;
            _classroom = classroom;
        }

        public string Name => _name;
        public string Day => _day;
        public string Time => _time;
        public string Teacher => _teacher;
        public int Classroom => _classroom;
    }
}