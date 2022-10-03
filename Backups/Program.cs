using Backups.Entities;

namespace Backups
{
    internal class Program
    {
        private static void Main()
        {
            string path2 = "C:/Users/Я/Desktop/ООП/OOP-2c/Backups.Tests/Files/SecondJob";
            var backup = new BackupJob(path2, new Single());
            backup.CreateDirectory();
            backup.Add("C:/Users/Я/Desktop/ООП/OOP-2c/Backups.Tests/Files/FileA.txt");
            backup.Add("C:/Users/Я/Desktop/ООП/OOP-2c/Backups.Tests/Files/FileB.txt");
            backup.CreateRestorePoint();
        }
    }
}
