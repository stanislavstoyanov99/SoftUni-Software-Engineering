namespace P01.Stream_Progress.Interfaces
{
    public interface IStream
    {
        int Length { get; }

        int BytesSent { get; }
    }
}
