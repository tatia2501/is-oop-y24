using System.Collections.Generic;

namespace IsuExtra.Entities
{
    public class Flow
    {
        private const int MaxNumberOfPlaces = 30;

        private Schedule _schedule;
        private List<StudentExtra> _students;
        public Flow(Schedule schedule)
        {
            _schedule = schedule;
            _students = new List<StudentExtra>();
        }

        public Schedule Schedule => _schedule;
        public List<StudentExtra> Students => _students;

        public void AddStudentsToFlow(StudentExtra student)
        {
            _students.Add(student);
        }

        public void RemoveStudentFromFlow(StudentExtra student)
        {
            _students.Remove(student);
        }
    }
}