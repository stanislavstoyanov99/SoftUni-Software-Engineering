namespace Singleton
{
    using System;
    using System.IO;
    using System.Collections.Generic;

    public class SingletonDataContainer : ISingletonContainer
    {
        private readonly Dictionary<string, int> capitals
            = new Dictionary<string, int>();

        public static SingletonDataContainer Instance { get; } =
            new SingletonDataContainer();

        private  SingletonDataContainer()
        {
            Console.WriteLine("Initializing singleton object");

            string[] elements = File.ReadAllLines("./../../../capitals.txt");

            for (int i = 0; i < elements.Length; i += 2)
            {
                this.capitals.Add(elements[i], int.Parse(elements[i + 1]));
            }
        }

        public int GetPopulation(string name)
        {
            return this.capitals[name];
        }
    }
}
