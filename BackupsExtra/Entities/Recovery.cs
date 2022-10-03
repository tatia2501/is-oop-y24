using System.IO;

namespace BackupsExtra.Entities
{
    public class Recovery
    {
        public void DoRecovery(string path)
        {
            File.Create(path);
        }
    }
}