using System.Collections.Generic;
using Isu.Entities;

namespace IsuExtra.Entities
{
    public class StudentExtra
    {
        internal const int MaxNumberOfOgnp = 2;

        private Student _student;
        private List<Flow> _ognp;
        private char _faculty;
        public StudentExtra(Student student)
        {
            _student = student;
            _ognp = new List<Flow>();
            _faculty = student.Group.GroupName.Groupname[0];
        }

        public Student Student => _student;
        public List<Flow> Ognp => _ognp;
        public char Faculty => _faculty;

        public void AddOgnpFlowToStudent(Flow ognp)
        {
            _ognp.Add(ognp);
        }

        public void RemoveOgnpFlowFromStudent(Flow ognp)
        {
            _ognp.Remove(ognp);
        }
    }
}