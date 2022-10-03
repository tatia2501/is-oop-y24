using System;
using Backups.Entities;
using Single = Backups.Entities.Single;

namespace BackupsExtra.Entities
{
    public class BackupJobExtra
    {
        public BackupJobExtra(BackupJob backupJob, ILogging logging)
        {
            BackupJob = backupJob;
            Logging = logging;
        }

        public ILogging Logging { get; set; }
        public BackupJob BackupJob { get; set; }

        public int GetNumberOfPointsInTimeLimit(DateTime date)
        {
            int num = 0;
            foreach (RestorePoint point in BackupJob.RestorePoints)
            {
                if (point.Date < date)
                {
                    num++;
                }
            }

            return num;
        }

        public void LimitRemove(Limit limit)
        {
            limit.LimitRemove(BackupJob);
            MakeLogging("Limit remove made");
        }

        public void MergePoints(RestorePoint point1, RestorePoint point2)
        {
            var merge = new MergePoints(point1, point2);
            if (BackupJob.Algorithm == new Single())
            {
                merge.DeletePoint(BackupJob);
            }
            else
            {
                merge.Merge(BackupJob);
            }

            MakeLogging("Merge of points made");
        }

        public void RecoveryToOriginalLocation(BackupFile file)
        {
            var recovery = new Recovery();
            recovery.DoRecovery(file.FullName);
            MakeLogging("Recovery to original location made");
        }

        public void RecoveryToDifferentLocation(BackupFile file, string newLocation)
        {
            var recovery = new Recovery();
            recovery.DoRecovery(newLocation + "/" + file.Name);
            MakeLogging("Recovery to different location made");
        }

        public void MakeLogging(string message)
        {
            Logging.SendMessage(message);
        }

        public void Save(string path)
        {
            var save = new Saving(path);
            save.Save(this);
        }
    }
}