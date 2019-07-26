﻿namespace PlayersAndMonsters.Core
{
    using System;
    using System.Reflection;
    using System.Text;

    using PlayersAndMonsters.Core.Contracts;
    using PlayersAndMonsters.IO.Contracts;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(ICommandInterpreter commandInterpreter, IReader reader, IWriter writer)
        {
            this.commandInterpreter = commandInterpreter;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string input = string.Empty;

            StringBuilder sb = new StringBuilder();

            while ((input = this.reader.ReadLine()) != "Exit")
            {
                string[] inputArgs = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    string result = this.commandInterpreter.Read(inputArgs);
                    this.writer.WriteLine(result);

                    sb.AppendLine(result);
                }
                catch (TargetInvocationException ex)
                {
                    this.writer.WriteLine(ex.InnerException.Message);

                    sb.AppendLine(ex.InnerException.Message);
                }
            }
        }
    }
}
