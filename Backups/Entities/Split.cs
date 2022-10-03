using System.Collections.Generic;
using Ionic.Zip;

namespace Backups.Entities
{
    public class Split : IAlgorithm
    {
        public List<string> Algorithm(List<BackupFile> files, string directory)
        {
            var filesPath = new List<string>();
            var zip = new ZipFile();
            foreach (BackupFile file in files)
            {
                zip.AddItem(file.FullName);
                string path = directory + file.Name + ".zip";
                zip.Save(path);
                filesPath.Add(path);
            }

            return filesPath;
        }
    }
}
