using Backups.Entities;

namespace BackupsExtra.Entities
{
    public abstract class Limit
    {
        public Limit(int numberOfPointsInLimit)
        {
            NumberOfPointsInLimit = numberOfPointsInLimit;
        }

        public int NumberOfPointsInLimit { get; set; }

        public abstract void LimitRemove(BackupJob backupJob);
    }
}