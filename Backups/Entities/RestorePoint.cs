using System;
using System.Collections.Generic;

namespace Backups.Entities
{
    public class RestorePoint
    {
        private DateTime _date;

        public RestorePoint(List<string> filesPath)
        {
            FilesPath = filesPath;
            _date = DateTime.Now;
        }

        public List<string> FilesPath { get; set; }
        public DateTime Date => _date;
    }
}
