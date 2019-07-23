using System;

using _01Logger.Factories;
using _01Logger.Models.Contracts;

namespace _01Logger.Core
{
    public class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        private Engine()
        {
            this.errorFactory = new ErrorFactory();    
        }

        public Engine(ILogger logger)
            : this()
        {
            this.logger = logger;
        }

        public void Run()
        {
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] errorArgs = command.Split("|");
                string level = errorArgs[0];
                string date = errorArgs[1];
                string message = errorArgs[2];

                IError error;

                try
                {
                    error = this.errorFactory.GetError(date, level, message);
                    this.logger.Log(error);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            Console.WriteLine(this.logger.ToString());
        }
    }
}
