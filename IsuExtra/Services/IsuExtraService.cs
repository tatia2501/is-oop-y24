using System.Collections.Generic;
using Isu.Entities;
using Isu.Services;
using IsuExtra.Entities;
using IsuExtra.Tools;

namespace IsuExtra.Services
{
    public class IsuExtraService : IsuService, IIsuExtraService
    {
        private List<OGNP> _someOgnp;
        private List<GroupSchedule> _groupSchedule;
        private List<StudentExtra> _allStudentsExtra;

        public IsuExtraService()
        {
            _someOgnp = new List<OGNP>();
            _groupSchedule = new List<GroupSchedule>();
            _allStudentsExtra = new List<StudentExtra>();
        }

        public OGNP AddOgnp(string name, char faculty)
        {
            var ognp = new OGNP(name, faculty);
            _someOgnp.Add(ognp);
            return ognp;
        }

        public Lesson AddLesson(string name, string day, string time, string teacher, int classroom)
        {
            return new Lesson(name, day, time, teacher, classroom);
        }

        public Schedule AddSchedule()
        {
            return new Schedule();
        }

        public Flow AddFlow(Schedule schedule)
        {
            return new Flow(schedule);
        }

        public GroupSchedule AddGroupSchedule(Group group, Schedule schedule)
        {
            var groupSchedule = new GroupSchedule(group, schedule);
            _groupSchedule.Add(groupSchedule);
            return groupSchedule;
        }

        public StudentExtra AddStudentExtra(Student student)
        {
            var studentExtra = new StudentExtra(student);
            _allStudentsExtra.Add(studentExtra);
            return studentExtra;
        }

        public void AddOgnpToStudent(OGNP ognp, StudentExtra studentExtra)
        {
            bool studentHasThisOgnp = false;
            foreach (Flow flow in ognp.Flows)
            {
                bool ognpSuitsStudent = true;
                foreach (GroupSchedule groupSchedule in _groupSchedule)
                {
                    if (studentExtra.Student.Group == groupSchedule.Group)
                    {
                        foreach (Lesson lesson in flow.Schedule.Lessons)
                        {
                            foreach (Lesson les in groupSchedule.Lessons.Lessons)
                            {
                                if (lesson.Time == les.Time & lesson.Day == les.Day
                                    || studentExtra.Ognp.Count > StudentExtra.MaxNumberOfOgnp
                                    || studentExtra.Faculty == ognp.Faculty)
                                {
                                    ognpSuitsStudent = false;
                                }
                            }
                        }
                    }
                }

                if (ognpSuitsStudent)
                {
                    studentExtra.AddOgnpFlowToStudent(flow);
                    flow.AddStudentsToFlow(studentExtra);
                    studentHasThisOgnp = true;
                    break;
                }
            }

            if (!studentHasThisOgnp)
            {
                throw new IsuExtraException("Student can't have this OGNP");
            }
        }

        public bool IsStudentInOgnp(StudentExtra studentExtra, OGNP ognp)
        {
            foreach (Flow flow in ognp.Flows)
            {
                foreach (StudentExtra student in flow.Students)
                {
                    if (student == studentExtra)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public List<StudentExtra> FindStudentsWithoutOgnp()
        {
            var result = new List<StudentExtra>();
            foreach (StudentExtra student in _allStudentsExtra)
            {
                if (student.Ognp.Count == 0)
                {
                    result.Add(student);
                }
            }

            if (result.Count == 0)
            {
                throw new IsuExtraException("Every student has OGNP");
            }

            return result;
        }

        public List<StudentExtra> GetStudentsFromOgnp(OGNP ognp)
        {
            var result = new List<StudentExtra>();
            foreach (Flow flow in ognp.Flows)
            {
                foreach (StudentExtra student in flow.Students)
                {
                    result.Add(student);
                }
            }

            if (result.Count == 0)
            {
                throw new IsuExtraException("There is no students in this OGNP");
            }

            return result;
        }

        public List<Flow> GetFlowsFromOgnp(OGNP ognp)
        {
            var result = new List<Flow>();
            foreach (Flow flow in ognp.Flows)
            {
                result.Add(flow);
            }

            if (result.Count == 0)
            {
                throw new IsuExtraException("There is no flows in this OGNP");
            }

            return result;
        }

        public void CancelOgnp(OGNP ognp, StudentExtra studentExtra)
        {
            Flow resultFlow = null;
            foreach (Flow flow in ognp.Flows)
            {
                foreach (StudentExtra student in flow.Students)
                {
                    if (student == studentExtra)
                    {
                        resultFlow = flow;
                    }
                }
            }

            if (resultFlow != null)
            {
                resultFlow.RemoveStudentFromFlow(studentExtra);
                studentExtra.RemoveOgnpFlowFromStudent(resultFlow);
            }
            else
            {
                throw new IsuExtraException("There is no such student in this OGNP");
            }
        }
    }
}