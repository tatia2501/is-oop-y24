using System.Collections.Generic;
using Ionic.Zip;

namespace Backups.Entities
{
    public class Single : IAlgorithm
    {
        private static int _id = 1;
        public List<string> Algorithm(List<BackupFile> files, string directory)
        {
            var filesPath = new List<string>();
            var zip = new ZipFile();
            foreach (BackupFile file in files)
            {
                zip.AddItem(file.FullName);
            }

            string path = directory + "/Archived" + _id.ToString() + ".zip";
            zip.Save(path);
            filesPath.Add(path);
            _id++;
            return filesPath;
        }
    }
}