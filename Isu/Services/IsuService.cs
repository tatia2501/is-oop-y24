using System.Collections.Generic;
using Isu.Entities;
using Isu.Tools;

namespace Isu.Services
{
    public class IsuService : IIsuService
    {
        private List<Course> _courses;
        private List<Student> _allStudents;

        public IsuService()
        {
            _courses = new List<Course>();
            for (int i = 1; i <= GroupName.MaxCourseNum; i++)
            {
                _courses.Add(new Course());
            }

            _allStudents = new List<Student>();
        }

        public Student AddStudent(Group group, string name)
        {
            var student = new Student(name);
            student.AddGroupToStudent(group);
            group.AddStudentToGroup(student);
            _allStudents.Add(student);
            return student;
        }

        public Student GetStudent(int id)
        {
            Student result = null;
            foreach (Student student in _allStudents)
            {
                if (student.ID == id)
                {
                    result = student;
                    break;
                }
            }

            if (result == null)
            {
                throw new IsuException("No students with such id");
            }

            return result;
        }

        public Student FindStudent(string name)
        {
            Student result = null;
            foreach (Student student in _allStudents)
            {
                if (student.Name == name)
                {
                    result = student;
                    break;
                }
            }

            if (result == null)
            {
                throw new IsuException("No students with such name");
            }

            return result;
        }

        public Group AddGroup(string name)
        {
            var groupname = new GroupName(name);
            var groap = new Group(groupname);
            int courseNum = int.Parse(name[2].ToString());
            _courses[courseNum - 1].AddGroupToCourse(groap);
            return groap;
        }

        public Group FindGroup(string groupName)
        {
            Group result = null;
            var groupname = new GroupName(groupName);
            foreach (Course course in _courses)
            {
                foreach (Group group in course.Groups)
                {
                        if (group.GroupName == groupname)
                        {
                            result = group;
                            break;
                        }
                }
            }

            if (result == null)
            {
                throw new IsuException("No groups with such name");
            }

            return result;
        }

        public List<Student> FindStudents(string groupName)
        {
            var result = new List<Student>();
            var groupname = new GroupName(groupName);
            foreach (Course course in _courses)
            {
                foreach (Group group in course.Groups)
                {
                    if (group.GroupName == groupname)
                    {
                        result.AddRange(group.Students);
                    }
                }
            }

            if (result.Count == 0)
            {
                throw new IsuException("No students in this group");
            }

            return result;
        }

        public List<Student> FindStudents(Course courseNumber)
        {
            var result = new List<Student>();
            foreach (Course course in _courses)
            {
                if (course == courseNumber)
                {
                    foreach (Group group in course.Groups)
                    {
                        result.AddRange(group.Students);
                    }
                }
            }

            if (result.Count == 0)
            {
                throw new IsuException("No students in this course");
            }

            return result;
        }

        public List<Group> FindGroups(Course courseNumber)
        {
            var result = new List<Group>();
            foreach (Course course in _courses)
            {
                if (course == courseNumber)
                {
                    result.AddRange(course.Groups);
                }
            }

            if (result.Count == 0)
            {
                throw new IsuException("No groups in this course");
            }

            return result;
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            Group group = student.Group;
            group.DeleteStudentFromGroup(student);
            newGroup.AddStudentToGroup(student);
            student.AddGroupToStudent(newGroup);
        }
    }
}
