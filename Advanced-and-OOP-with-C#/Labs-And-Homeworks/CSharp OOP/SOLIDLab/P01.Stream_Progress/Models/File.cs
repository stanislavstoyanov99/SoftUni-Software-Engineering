using P01.Stream_Progress.Interfaces;

namespace P01.Stream_Progress.Models
{
    public class File : IStream
    {
        private readonly string name;

        public File(string name, int length, int bytesSent)
        {
            this.name = name;

            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public int Length { get; private set; }

        public int BytesSent { get; private set; }
    }
}
