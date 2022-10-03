using System.Collections.Generic;

namespace Backups.Entities
{
    public interface IAlgorithm
    {
        List<string> Algorithm(List<BackupFile> files, string directory);
    }
}