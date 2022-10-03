using System.Collections.Generic;
using Isu.Tools;

namespace Isu.Entities
{
    public class Group
    {
        private const int MaxStudentNum = 5;

        private GroupName _groupName;
        private List<Student> _students;

        public Group(GroupName name)
        {
            _groupName = name;
            _students = new List<Student>();
        }

        public GroupName GroupName => _groupName;
        public List<Student> Students => _students;

        public Student FindStudentInGroup(Student student)
        {
            Student result = null;
            foreach (Student student1 in _students)
            {
                if (student1 == student)
                {
                    result = student1;
                    break;
                }
            }

            return result;
        }

        public void AddStudentToGroup(Student student)
        {
            if (_students.Count >= MaxStudentNum)
            {
                throw new IsuException("Max student number reached");
            }

            _students.Add(student);
        }

        public void DeleteStudentFromGroup(Student student)
        {
            _students.Remove(student);
        }
    }
}
