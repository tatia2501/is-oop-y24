using System;
using System.IO;

namespace BackupsExtra.Entities
{
    public class FileLogging : ILogging
    {
        public void SendMessage(string message)
        {
            var file = new StreamWriter("./../../../Logging.txt");
            file.WriteLine(DateTime.Now.ToString("g"));
            file.WriteLine(message);
            file.Close();
        }
    }
}