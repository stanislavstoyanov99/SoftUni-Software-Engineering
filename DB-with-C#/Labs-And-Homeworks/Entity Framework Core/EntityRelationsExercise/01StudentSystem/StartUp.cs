namespace P01_StudentSystem
{
    using P01_StudentSystem.Data;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var db = new StudentSystemContext();
        }
    }
}
