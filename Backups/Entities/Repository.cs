using System.IO;

namespace Backups.Entities
{
    public class Repository
    {
        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }
    }
}