using System;
using System.IO;
using Backups.Entities;
using BackupsExtra.Entities;
using NUnit.Framework;

namespace BackupsExtra.Tests
{
    class BackupsExtraTest
    {
        private BackupJob _backup;
        private BackupJobExtra _backupExtra;
        
        [SetUp]
        public void Setup()
        {
            string path = "./FirstJob";
            _backup = new BackupJob(path, new Split());
            _backup.CreateDirectory();
            _backupExtra = new BackupJobExtra(_backup, new ConsoleLogging());
            _backupExtra.MakeLogging("BackupJob created");
        }

        [Test]
        public void DeletePointsBecauseOfTimeLimit()
        {
            _backupExtra.BackupJob.Add("./../../../Files/FileA.txt");
            _backupExtra.BackupJob.Add("./../../../Files/FileB.txt");
            _backupExtra.BackupJob.CreateRestorePoint();
            DateTime date = DateTime.Now;
            _backupExtra.BackupJob.Remove("./../../../Files/FileB.txt");
            _backupExtra.BackupJob.CreateRestorePoint();

            var timeLimit = new TimeLimit(_backupExtra.GetNumberOfPointsInTimeLimit(date));
            _backupExtra.LimitRemove(timeLimit);
            Assert.True(_backupExtra.BackupJob.RestorePoints.Count == 1);
            Assert.AreEqual(_backupExtra.BackupJob.RestorePoints[0].FilesPath[0], "./FirstJob/RestorePoint2/FileA.zip");
            Directory.Delete("./FirstJob", true);
        }

        [Test]
        public void MergePoints()
        {
            _backupExtra.BackupJob.Add("./../../../Files/FileA.txt");
            _backupExtra.BackupJob.CreateRestorePoint();
            _backupExtra.BackupJob.Add("./../../../Files/FileB.txt");
            _backupExtra.BackupJob.CreateRestorePoint();
            _backupExtra.MergePoints(_backupExtra.BackupJob.RestorePoints[1], _backupExtra.BackupJob.RestorePoints[0]);
            
            Assert.True(_backupExtra.BackupJob.RestorePoints.Count == 1);
            Assert.AreEqual(_backupExtra.BackupJob.RestorePoints[0].FilesPath[0], "./FirstJob/RestorePoint2/FileA.zip");
            Directory.Delete("./FirstJob", true);
        }

        [Test]
        public void Recovery()
        {
            _backupExtra.BackupJob.Add("./../../../Files/FileA.txt");
            _backupExtra.BackupJob.Add("./../../../Files/FileB.txt");
            _backupExtra.BackupJob.CreateRestorePoint();
            File.Delete("./../../../Files/FileA.txt");
            _backupExtra.RecoveryToOriginalLocation(_backupExtra.BackupJob.BackupFiles[0]);
            Assert.True(File.Exists("./../../../Files/FileA.txt"));

            Directory.Delete("./FirstJob", true);
        }
    }
}

