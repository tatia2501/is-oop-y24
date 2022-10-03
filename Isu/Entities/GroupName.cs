using Isu.Tools;

namespace Isu.Entities
{
    public class GroupName
    {
        internal const int MaxCourseNum = 4;
        private const int MaxGroupNum = 15;

        private string _groupName;

        public GroupName(string name)
        {
            if (!IsNameAllowed(name))
            {
                throw new IsuException("Name is not allowed");
            }

            _groupName = name;
        }

        public string Groupname => _groupName;
        private static bool IsNameAllowed(string name)
        {
            return (name[0] >= 'A' & name[0] <= 'Z') & (int.Parse(name[1].ToString()) >= 1 & int.Parse(name[1].ToString()) <= 9) & (int.Parse(name[2].ToString()) <= MaxCourseNum) & (int.Parse(name[3..4]) <= MaxGroupNum);
        }
    }
}
