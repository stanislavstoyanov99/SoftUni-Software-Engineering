using System.IO;

using _01Logger.Models.Contracts;

namespace _01Logger.Models.IOManagement
{
    public class IOManager : IIOManager
    {
        private string currentPath;
        private string currentDirectory;
        private string currentFile;

        private IOManager()
        {
            this.currentPath = GetCurrentPath();
        }

        public IOManager(string currentDirectory, string currentFile)
            : this()
        {
            this.currentDirectory = currentDirectory;
            this.currentFile = currentFile;
        }

        public string CurrentDirectoryPath => this.currentPath + this.currentDirectory;

        public string CurrentFilePath => this.CurrentDirectoryPath + this.currentFile;

        public void EnsureDirectoryAndFileExist()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }

            File.WriteAllText(this.CurrentFilePath, "");
        }

        public string GetCurrentPath()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
