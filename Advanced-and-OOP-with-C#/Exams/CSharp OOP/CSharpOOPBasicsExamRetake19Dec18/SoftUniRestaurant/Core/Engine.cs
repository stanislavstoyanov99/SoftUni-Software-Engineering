namespace SoftUniRestaurant.Core
{
    using System;
    using System.Reflection;

    using SoftUniRestaurant.Core.Contracts;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    string result = this.commandInterpreter.Read(inputArgs);

                    Console.WriteLine(result);
                }
                catch (TargetInvocationException ex)
                {
                    Console.WriteLine($"{ex.InnerException.Message}");
                }
            }

            Console.WriteLine(this.commandInterpreter.WriteSummary());
        }
    }
}
