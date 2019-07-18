using P01.Stream_Progress.Interfaces;

namespace P01.Stream_Progress.Models
{
    public class FutureStream : IStream
    {
        public FutureStream(int length, int bytesSent)
        {
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public int Length { get; private set; }

        public int BytesSent { get; private set; }
    }
}
