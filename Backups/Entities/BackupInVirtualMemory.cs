using System;
using System.Collections.Generic;
using System.IO;

namespace Backups.Entities
{
    public class BackupInVirtualMemory
    {
        private List<string> _files;
        private string _date;

        public BackupInVirtualMemory(List<BackupFile> backupFiles)
        {
            _date = DateTime.Today.ToString("g");
            _files = new List<string>(backupFiles.Count);
            for (int i = 0; i < backupFiles.Count; i++)
            {
                _files[i] = File.ReadAllText(backupFiles[i].FullName);
            }
        }

        public List<string> Files => _files;
        public string Date => _date;
    }
}