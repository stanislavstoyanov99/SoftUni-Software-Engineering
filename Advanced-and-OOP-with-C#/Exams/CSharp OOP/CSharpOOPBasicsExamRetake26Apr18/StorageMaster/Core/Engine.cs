using System;
using System.Linq;

using StorageMaster.Core.Contracts;

namespace StorageMaster.Core
{
    public class Engine : IEngine
    {
        private readonly StorageMaster storageMaster;

        public Engine()
        {
            this.storageMaster = new StorageMaster();
        }

        public void Run()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string commandResult = ProcessCommand(input);

                    Console.WriteLine(commandResult);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            Console.WriteLine(this.storageMaster.GetSummary());
        }

        private string ProcessCommand(string command)
        {
            string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandName = commandArgs[0];

            string[] args = commandArgs
                .Skip(1)
                .ToArray();

            string result = string.Empty;

            switch (commandName)
            {
                case "AddProduct":
                    {
                        string productType = args[0];
                        double price = double.Parse(args[1]);

                        result = this.storageMaster.AddProduct(productType, price);
                        break;
                    }
                case "RegisterStorage":
                    {
                        string storageType = args[0];
                        string name = args[1];

                        result = this.storageMaster.RegisterStorage(storageType, name);
                        break;
                    }
                case "SelectVehicle":
                    {
                        string storageName = args[0];
                        int garageSlot = int.Parse(args[1]);

                        result = this.storageMaster.SelectVehicle(storageName, garageSlot);
                        break;
                    }
                case "LoadVehicle":
                    {
                        string[] productNames = args;

                        result = this.storageMaster.LoadVehicle(productNames);
                        break;
                    }
                case "SendVehicleTo":
                    {
                        string sourceName = args[0];
                        int sourceGarageSlot = int.Parse(args[1]);
                        string destinationName = args[2];

                        result = this.storageMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName);
                        break;
                    }
                case "UnloadVehicle":
                    {
                        string storageName = args[0];
                        int garageSlot = int.Parse(args[1]);

                        result = this.storageMaster.UnloadVehicle(storageName, garageSlot);
                        break;
                    }
                case "GetStorageStatus":
                    {
                        string storageName = args[0];

                        result = this.storageMaster.GetStorageStatus(storageName);
                        break;
                    }
            }

            return result;
        }
    }
}
