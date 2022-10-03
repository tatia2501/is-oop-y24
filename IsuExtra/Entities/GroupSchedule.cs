using Isu.Entities;

namespace IsuExtra.Entities
{
    public class GroupSchedule
    {
        private Schedule _lessons;
        private Group _group;

        public GroupSchedule(Group group, Schedule schedule)
        {
            _lessons = schedule;
            _group = group;
        }

        public Schedule Lessons => _lessons;
        public Group Group => _group;
    }
}
