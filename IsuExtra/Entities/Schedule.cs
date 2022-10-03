using System.Collections.Generic;

namespace IsuExtra.Entities
{
    public class Schedule
    {
        private List<Lesson> _lessons;

        public Schedule()
        {
            _lessons = new List<Lesson>();
        }

        public List<Lesson> Lessons => _lessons;

        public void AddLessonToSchedule(Lesson lesson)
        {
            _lessons.Add(lesson);
        }
    }
}