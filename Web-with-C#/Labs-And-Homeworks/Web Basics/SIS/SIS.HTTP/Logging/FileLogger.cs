namespace SIS.HTTP.Logging
{
    using System;
    using System.IO;
    using System.Collections.Generic;

    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            IList<string> fileContent = new List<string>
            {
                $"[{ DateTime.Now.ToString("r")}] {message}"
            };

            File.AppendAllLines("log.txt", fileContent);
        }
    }
}
