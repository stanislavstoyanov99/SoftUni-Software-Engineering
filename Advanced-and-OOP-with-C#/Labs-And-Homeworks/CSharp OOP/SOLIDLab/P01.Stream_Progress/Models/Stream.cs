using P01.Stream_Progress.Interfaces;

namespace P01.Stream_Progress.Models
{
    public abstract class Stream : IStream
    {
        public int Length { get; protected set; }

        public int BytesSent { get; protected set; }
    }
}
