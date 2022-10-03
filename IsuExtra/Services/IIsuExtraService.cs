using System.Collections.Generic;
using Isu.Entities;
using Isu.Services;
using IsuExtra.Entities;

namespace IsuExtra.Services
{
    public interface IIsuExtraService : IIsuService
    {
        OGNP AddOgnp(string name, char faculty);
        Lesson AddLesson(string name, string day, string time, string teacher, int classroom);
        Schedule AddSchedule();
        Flow AddFlow(Schedule schedule);
        GroupSchedule AddGroupSchedule(Group group, Schedule schedule);
        StudentExtra AddStudentExtra(Student student);
        void AddOgnpToStudent(OGNP ognp, StudentExtra studentExtra);
        bool IsStudentInOgnp(StudentExtra studentExtra, OGNP ognp);
        List<StudentExtra> FindStudentsWithoutOgnp();
        List<StudentExtra> GetStudentsFromOgnp(OGNP ognp);
        void CancelOgnp(OGNP ognp, StudentExtra student);
    }
}