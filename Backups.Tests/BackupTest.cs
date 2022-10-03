using Backups.Entities;
using System.IO;
using NUnit.Framework;

namespace Backups.Tests
{
    public class Tests
    {
        private BackupJob _backup;
        
        [SetUp]
        public void Setup()
        {
            string path = "./FirstJob";
            _backup = new BackupJob(path, new Split());
            _backup.CreateDirectory();
        }

        [Test]
        public void Check_SplitStorages()
        {
            _backup.Add("./../../../Files/FileA.txt");
            _backup.Add("./../../../Files/FileB.txt");
            _backup.CreateRestorePoint();
            _backup.Remove("./FileB.txt");
            _backup.CreateRestorePoint();
            Assert.AreEqual(_backup.RestorePoints[0].FilesPath[0], "./FirstJob/RestorePoint1/FileA.zip");
            Assert.AreEqual(_backup.RestorePoints[0].FilesPath[1], "./FirstJob/RestorePoint1/FileB.zip");
            Assert.AreEqual(_backup.RestorePoints[1].FilesPath[0], "./FirstJob/RestorePoint2/FileA.zip");
            Directory.Delete("./FirstJob", true);
        }


    }
}
