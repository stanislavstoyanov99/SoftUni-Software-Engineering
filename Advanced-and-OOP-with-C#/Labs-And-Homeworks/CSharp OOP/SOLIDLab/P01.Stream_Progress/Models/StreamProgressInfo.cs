using P01.Stream_Progress.Interfaces;

namespace P01.Stream_Progress.Models
{
    public class StreamProgressInfo
    {
        private readonly IStream stream;

        public StreamProgressInfo(IStream stream)
        {
            this.stream = stream;
        }

        public int CalculateCurrentPercent()
        {
            return (this.stream.BytesSent * 100) / this.stream.Length;
        }
    }
}
