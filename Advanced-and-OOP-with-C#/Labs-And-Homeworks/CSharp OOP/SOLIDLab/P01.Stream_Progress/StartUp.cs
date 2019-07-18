using P01.Stream_Progress.Interfaces;
using P01.Stream_Progress.Models;

namespace P01.Stream_Progress
{
    public class StartUp
    {
        public static void Main()
        {
            IStream file = new File("Pesho", 5, 10);
            IStream music = new Music("Pesho", "Peshoniada", 50, 10);
            IStream futureStream = new FutureStream(10, 200);

            StreamProgressInfo fileStreamInfo = new StreamProgressInfo(file);
            StreamProgressInfo musicStreamInfo = new StreamProgressInfo(music);
            StreamProgressInfo futureStreamInfo = new StreamProgressInfo(futureStream);
        }
    }
}
