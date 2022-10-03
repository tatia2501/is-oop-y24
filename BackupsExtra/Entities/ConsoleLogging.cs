using System;

namespace BackupsExtra.Entities
{
    public class ConsoleLogging : ILogging
    {
        public void SendMessage(string message)
        {
            Console.WriteLine(DateTime.Now.ToString("g"));
            Console.WriteLine(message);
        }
    }
}