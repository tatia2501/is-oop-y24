using Backups.Entities;

namespace BackupsExtra.Entities
{
    public class MergePoints
    {
        private RestorePoint _new;
        private RestorePoint _old;

        public MergePoints(RestorePoint point1, RestorePoint point2)
        {
            _new = point1;
            _old = point2;
        }

        public void Merge(BackupJob backupJob)
        {
            foreach (string path1 in _old.FilesPath)
            {
                bool presence = true;
                foreach (string path2 in _new.FilesPath)
                {
                    if (path1 == path2)
                    {
                        presence = false;
                    }
                }

                if (presence)
                {
                    _new.FilesPath.Add(path1);
                }
            }

            backupJob.RestorePoints.Remove(_old);
        }

        public void DeletePoint(BackupJob backupJob)
        {
            backupJob.RestorePoints.Remove(_old);
        }
    }
}