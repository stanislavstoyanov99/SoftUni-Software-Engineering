using System;

using ViceCity.Core.Contracts;
using ViceCity.IO.Contracts;
using ViceCity.IO;

namespace ViceCity.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IController controller;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();

            this.controller = new Controller();

        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();

                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }

                string result = string.Empty;

                try
                {
                    if (input[0] == "AddPlayer")
                    {
                        string playerUsername = input[1];

                        result = this.controller.AddPlayer(playerUsername);
                        this.writer.WriteLine(result);
                    }
                    else if (input[0] == "AddGun")
                    {
                        string gunType = input[1];
                        string gunName = input[2];

                        result = this.controller.AddGun(gunType, gunName);
                        this.writer.WriteLine(result);
                    }
                    else if (input[0] == "AddGunToPlayer")
                    {
                        string playerName = input[1];

                        result = this.controller.AddGunToPlayer(playerName);
                        this.writer.WriteLine(result);
                    }
                    else if (input[0] == "Fight")
                    {
                        result = this.controller.Fight();
                        this.writer.WriteLine(result);
                    }
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
