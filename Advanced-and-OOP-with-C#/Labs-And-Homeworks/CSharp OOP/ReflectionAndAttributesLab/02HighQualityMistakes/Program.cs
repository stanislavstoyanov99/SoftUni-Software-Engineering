using System;

namespace _02HighQualityMistakes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.AnalyzeAcessModifiers("Hacker");

            Console.WriteLine(result);
        }
    }
}
