namespace Singleton
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            SingletonDataContainer db = SingletonDataContainer.Instance;
            Console.WriteLine(db.GetPopulation("Sofia"));

            var db2 = SingletonDataContainer.Instance;
            Console.WriteLine(db.GetPopulation("Berlin"));

            var db3 = SingletonDataContainer.Instance;
            Console.WriteLine(db.GetPopulation("Ankara"));

            var db4 = SingletonDataContainer.Instance;
        }
    }
}
