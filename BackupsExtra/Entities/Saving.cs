using System.IO;
using System.Text.Json;

namespace BackupsExtra.Entities
{
    public class Saving
    {
        private string _path;

        public Saving(string path)
        {
            _path = path;
        }

        public void Save(BackupJobExtra backupJob)
        {
            string jsonString = JsonSerializer.Serialize(backupJob);
            File.WriteAllText(_path + "/Saving.json", jsonString);
        }

        public void Get()
        {
            string jsonString = File.ReadAllText(_path + "Saving.json");
            BackupJobExtra backupJob = JsonSerializer.Deserialize<BackupJobExtra>(jsonString);
        }
    }
}