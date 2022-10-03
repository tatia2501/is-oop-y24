using System.Collections.Generic;

namespace Backups.Entities
{
    public class BackupJob
    {
        public BackupJob(string path, IAlgorithm algorithm)
        {
            Path = path;
            BackupFiles = new List<BackupFile>();
            RestorePoints = new List<RestorePoint>();
            Algorithm = algorithm;
            Repository = new Repository();
            VirtualRestorePoints = new List<BackupInVirtualMemory>();
        }

        public string Path { get; set; }
        public List<BackupFile> BackupFiles { get; set; }
        public IAlgorithm Algorithm { get; set; }
        public Repository Repository { get; set; }
        public List<BackupInVirtualMemory> VirtualRestorePoints { get; set; }
        public List<RestorePoint> RestorePoints { get; set; }
        public void Add(string fullPath)
        {
            BackupFiles.Add(new BackupFile(fullPath));
        }

        public void Remove(string fullPath)
        {
            foreach (BackupFile file in BackupFiles)
            {
                if (file.FullName == fullPath)
                {
                    BackupFiles.Remove(file);
                    break;
                }
            }
        }

        public void CreateRestorePoint()
        {
            string restorePointPath = Path + "/RestorePoint" + (RestorePoints.Count + 1).ToString();
            Repository.CreateDirectory(restorePointPath);
            List<string> filePath;
            filePath = Algorithm.Algorithm(BackupFiles, restorePointPath);
            RestorePoints.Add(new RestorePoint(filePath));
        }

        public void CreateDirectory()
        {
            Repository.CreateDirectory(Path);
        }

        public void CreateRestorePointInVirtualMemory()
        {
            VirtualRestorePoints.Add(new BackupInVirtualMemory(BackupFiles));
        }
    }
}