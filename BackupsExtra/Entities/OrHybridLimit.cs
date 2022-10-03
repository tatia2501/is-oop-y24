using System;
using Backups.Entities;

namespace BackupsExtra.Entities
{
    public class OrHybridLimit : Limit
    {
        private int _numberOfPointsInSecondLimit;

        public OrHybridLimit(int numberOfPointsInLimit, int numberOfPointsInSecondLimit)
            : base(numberOfPointsInLimit)
        {
            _numberOfPointsInSecondLimit = numberOfPointsInSecondLimit;
        }

        public override void LimitRemove(BackupJob backupJob)
        {
            for (int i = 0; i < Math.Min(NumberOfPointsInLimit, _numberOfPointsInSecondLimit); i++)
            {
                backupJob.RestorePoints.Remove(backupJob.RestorePoints[0]);
            }
        }
    }
}