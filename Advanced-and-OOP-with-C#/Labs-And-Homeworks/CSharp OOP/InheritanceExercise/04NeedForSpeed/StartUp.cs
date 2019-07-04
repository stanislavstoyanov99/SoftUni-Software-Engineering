using NeedForSpeed.Motorcycles;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Motorcycle motorCycle = new Motorcycle(200, 50);
            motorCycle.Drive(100);
        }
    }
}
