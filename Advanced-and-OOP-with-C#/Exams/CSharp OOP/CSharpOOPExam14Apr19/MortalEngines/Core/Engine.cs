using System;
using System.Reflection;
using MortalEngines.Core.Contracts;
using MortalEngines.IO.Contracts;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        private readonly IWriter writer;

        public Engine(ICommandInterpreter commandInterpreter, IWriter writer)
        {
            this.commandInterpreter = commandInterpreter;
            this.writer = writer;
        }

        public void Run()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Quit")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    string result = this.commandInterpreter.Read(inputArgs);
                    this.writer.Write(result);
                }
                catch (TargetInvocationException ex)
                {
                    this.writer.Write($"Error: {ex.InnerException.Message}");
                }
            }
        }
    }
}
