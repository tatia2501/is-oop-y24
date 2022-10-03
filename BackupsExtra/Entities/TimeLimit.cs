using System;
using Backups.Entities;

namespace BackupsExtra.Entities
{
    public class TimeLimit : Limit
    {
        public TimeLimit(int numberOfPointsInLimit)
            : base(numberOfPointsInLimit)
        {
        }

        public override void LimitRemove(BackupJob backupJob)
        {
            for (int i = 0; i < NumberOfPointsInLimit; i++)
            {
                backupJob.RestorePoints.Remove(backupJob.RestorePoints[0]);
            }
        }
    }
}