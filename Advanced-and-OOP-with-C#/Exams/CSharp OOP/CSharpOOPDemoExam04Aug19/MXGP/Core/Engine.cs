namespace MXGP.Core
{
    using System;
    using System.Text;
    using System.Reflection;

    using MXGP.Core.Contracts;
    using MXGP.IO.Contracts;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter, IReader reader, IWriter writer)
        {
            this.commandInterpreter = commandInterpreter;
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            string input = string.Empty;

            while ((input = this.reader.ReadLine()) != "End")
            {
                string[] inputArgs = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    string result = this.commandInterpreter.Read(inputArgs);
                    this.writer.WriteLine(result);
                }
                catch (TargetInvocationException ex)
                {
                    this.writer.WriteLine(ex.InnerException.Message);
                }
            }
        }
    }
}
