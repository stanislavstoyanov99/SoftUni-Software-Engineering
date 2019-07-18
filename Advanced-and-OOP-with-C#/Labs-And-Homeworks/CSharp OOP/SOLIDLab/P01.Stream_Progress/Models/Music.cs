using P01.Stream_Progress.Interfaces;

namespace P01.Stream_Progress.Models
{
    public class Music: IStream
    {
        private readonly string artist;
        private readonly string album;

        public Music(string artist, string album, int length, int bytesSent)
        {
            this.artist = artist;
            this.album = album;

            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public int Length { get; private set; }

        public int BytesSent { get; private set; }
    }
}
