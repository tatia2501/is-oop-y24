using Isu.Services;
using Isu.Tools;
using Isu.Entities;
using NUnit.Framework;

namespace Isu.Tests
{
    public class Tests
    {
        private IIsuService _isuService;

        [SetUp]
        public void Setup()
        {
            //TODO: implement
            _isuService = new IsuService();
        }

        [Test]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            Group group1 = _isuService.AddGroup("M3203");
            Student student1 = _isuService.AddStudent(group1, "Tatiana Golyakova");
            Group result1 = student1.Group;
            Student result2 = group1.FindStudentInGroup(student1);
            Assert.AreEqual(group1, result1);
            Assert.AreEqual(student1, result2);
        }

        [Test]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            Group group2 = _isuService.AddGroup("M3205");
            Student student21 = _isuService.AddStudent(group2, "Maria Teterina");
            Student student22 = _isuService.AddStudent(group2, "Sofia Vyatkina");
            Student student23 = _isuService.AddStudent(group2, "Alsu Sadukova");
            Student student24 = _isuService.AddStudent(group2, "Max Shein");
            Student student25 = _isuService.AddStudent(group2, "Ivan Hryakov");
            Assert.Catch<IsuException>(() =>
            {
                Student student1 = _isuService.AddStudent(group2, "Denis Holopov");
            });
        }

        [Test]
        public void CreateGroupWithInvalidName_ThrowException()
        {
            Assert.Catch<IsuException>(() =>
            {
                Group group3 = _isuService.AddGroup("H0118");
            });
        }

        [Test]
        public void TransferStudentToAnotherGroup_GroupChanged()
        {
            Group group41 = _isuService.AddGroup("M3205");
            Group group42 = _isuService.AddGroup("M3200");
            Student student4 = _isuService.AddStudent(group41, "Komova Anna");
            _isuService.ChangeStudentGroup(student4, group42);
            Group result = student4.Group;
            Assert.AreEqual(group42, result);
        }
    }
}
