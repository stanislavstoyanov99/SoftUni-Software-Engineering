namespace SulsApp.Services
{
    using System;
    using System.Text;

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("r")}] {message}");
        }
    }
}
