using System.Collections.Generic;
using IsuExtra.Services;
using IsuExtra.Entities;
using IsuExtra.Tools;
using Isu.Entities;
using NUnit.Framework;

namespace IsuExtra.Tests
{
    public class Tests
    {
        private IIsuExtraService _isuExtraService;

        [SetUp]
        public void Setup()
        {
            _isuExtraService = new IsuExtraService();
        }

        [Test]
        public void AddStudentToOgnp()
        {
            OGNP ognp1 = _isuExtraService.AddOgnp("kiberbez", 'N');
            Lesson lesson1 = _isuExtraService.AddLesson("kiberbez", "mn", "8.20", "Petrov", 302);
            Lesson lesson2 = _isuExtraService.AddLesson("kiberbez", "mn", "10.00", "Petrov", 302);
            Schedule schedule1 = _isuExtraService.AddSchedule();
            schedule1.AddLessonToSchedule(lesson1);
            schedule1.AddLessonToSchedule(lesson2);
            Flow flow1 = _isuExtraService.AddFlow(schedule1);
            ognp1.AddFLowToOgnp(flow1);

            Group group1 = _isuExtraService.AddGroup("M3203");
            Student student1 = _isuExtraService.AddStudent(group1, "Tatiana Golyakova");
            StudentExtra studentExtra1 = _isuExtraService.AddStudentExtra(student1);
            Lesson lesson3 = _isuExtraService.AddLesson("math", "mn", "8.20", "Sidorov", 230);
            Schedule schedule3 = _isuExtraService.AddSchedule();
            schedule3.AddLessonToSchedule(lesson3);
            _isuExtraService.AddGroupSchedule(group1, schedule3);

            Assert.Catch<IsuExtraException>(() =>
            {
                _isuExtraService.AddOgnpToStudent(ognp1, studentExtra1);
            });

            Lesson lesson4 = _isuExtraService.AddLesson("kiberbez", "th", "8.20", "Smirnov", 105);
            Lesson lesson5 = _isuExtraService.AddLesson("kiberbez", "th", "10.00", "Smirnov", 105);
            Schedule schedule2 = _isuExtraService.AddSchedule();
            schedule2.AddLessonToSchedule(lesson4);
            schedule2.AddLessonToSchedule(lesson5);
            Flow flow2 = _isuExtraService.AddFlow(schedule2);
            ognp1.AddFLowToOgnp(flow2);

            _isuExtraService.AddOgnpToStudent(ognp1, studentExtra1);
            Assert.True(_isuExtraService.IsStudentInOgnp(studentExtra1, ognp1));
        }

        [Test]
        public void CancelOgnp()
        {
            OGNP ognp1 = _isuExtraService.AddOgnp("linux", 'G');
            Lesson lesson1 = _isuExtraService.AddLesson("linux", "mn", "13.30", "Vasutkin", 328);
            Lesson lesson2 = _isuExtraService.AddLesson("linux", "mn", "15.00", "Vasutkin", 328);
            Schedule schedule1 = _isuExtraService.AddSchedule();
            schedule1.AddLessonToSchedule(lesson1);
            schedule1.AddLessonToSchedule(lesson2);
            Flow flow1 = _isuExtraService.AddFlow(schedule1);
            ognp1.AddFLowToOgnp(flow1);

            Group group1 = _isuExtraService.AddGroup("Q2200");
            Student student1 = _isuExtraService.AddStudent(group1, "Anna Komova");
            StudentExtra studentExtra1 = _isuExtraService.AddStudentExtra(student1);
            Lesson lesson3 = _isuExtraService.AddLesson("math", "wd", "11.40", "Sidorov", 230);
            Schedule schedule2 = _isuExtraService.AddSchedule();
            schedule2.AddLessonToSchedule(lesson3);
            _isuExtraService.AddGroupSchedule(group1, schedule2);

            _isuExtraService.AddOgnpToStudent(ognp1, studentExtra1);
            _isuExtraService.CancelOgnp(ognp1, studentExtra1);
            Assert.False(_isuExtraService.IsStudentInOgnp(studentExtra1, ognp1));
        }

        [Test]
        public void FindStudentsWhoHasNotOgnp()
        {
            Group group1 = _isuExtraService.AddGroup("H3209");
            Student student1 = _isuExtraService.AddStudent(group1, "First Person");
            Student student2 = _isuExtraService.AddStudent(group1, "Second Person");
            Student student3 = _isuExtraService.AddStudent(group1, "Third Person");
            StudentExtra studentExtra1 = _isuExtraService.AddStudentExtra(student1);
            StudentExtra studentExtra2 = _isuExtraService.AddStudentExtra(student2);
            StudentExtra studentExtra3 = _isuExtraService.AddStudentExtra(student3);
            Lesson lesson2 = _isuExtraService.AddLesson("physics", "mn", "13.30", "Vasutkin", 152);
            Lesson lesson3 = _isuExtraService.AddLesson("physics", "th", "15.00", "Vasutkin", 246);
            Lesson lesson4 = _isuExtraService.AddLesson("physics", "st", "13.30", "Vasutkin", 367);
            Schedule schedule2 = _isuExtraService.AddSchedule();
            Schedule schedule3 = _isuExtraService.AddSchedule();
            Schedule schedule4 = _isuExtraService.AddSchedule();
            schedule2.AddLessonToSchedule(lesson2);
            schedule3.AddLessonToSchedule(lesson3);
            schedule4.AddLessonToSchedule(lesson4);
            _isuExtraService.AddGroupSchedule(group1, schedule2);
            _isuExtraService.AddGroupSchedule(group1, schedule3);
            _isuExtraService.AddGroupSchedule(group1, schedule4);

            OGNP ognp1 = _isuExtraService.AddOgnp("innovatika", 'T');
            Lesson lesson1 = _isuExtraService.AddLesson("innovatika", "fr", "11.40", "Ivanov", 224);
            Schedule schedule1 = _isuExtraService.AddSchedule();
            schedule1.AddLessonToSchedule(lesson1);
            Flow flow1 = _isuExtraService.AddFlow(schedule1);
            ognp1.AddFLowToOgnp(flow1);

            _isuExtraService.AddOgnpToStudent(ognp1, studentExtra2);
            List<StudentExtra> students = _isuExtraService.FindStudentsWithoutOgnp();
            Assert.AreEqual(studentExtra1, students[0]);
            Assert.AreEqual(studentExtra3, students[1]);
        }
    }
}