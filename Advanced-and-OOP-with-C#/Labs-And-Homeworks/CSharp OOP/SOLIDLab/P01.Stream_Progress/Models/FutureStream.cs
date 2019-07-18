using P01.Stream_Progress.Interfaces;

namespace P01.Stream_Progress.Models
{
    public class FutureStream : Stream
    {
        public FutureStream(int length, int bytesSent)
        {
            this.Length = length;
            this.BytesSent = bytesSent;
        }
    }
}
