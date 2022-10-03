using System;
using Backups.Entities;

namespace BackupsExtra.Entities
{
    public class AndHybridLimit : Limit
    {
        private int _numberOfPointsInSecondLimit;

        public AndHybridLimit(int numberOfPointsInLimit, int numberOfPointsInSecondLimit)
            : base(numberOfPointsInLimit)
        {
            _numberOfPointsInSecondLimit = numberOfPointsInSecondLimit;
        }

        public override void LimitRemove(BackupJob backupJob)
        {
            for (int i = 0; i < Math.Max(NumberOfPointsInLimit, _numberOfPointsInSecondLimit); i++)
            {
                backupJob.RestorePoints.Remove(backupJob.RestorePoints[0]);
            }
        }
    }
}