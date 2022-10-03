using System.Collections.Generic;

namespace Isu.Entities
{
    public class Course
    {
        private List<Group> _groups;

        public Course()
        {
            _groups = new List<Group>();
        }

        public List<Group> Groups => _groups;

        public void AddGroupToCourse(Group group)
        {
            _groups.Add(group);
        }
    }
}
