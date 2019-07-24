using System;

using MortalEngines.Core.Contracts;
using MortalEngines.IO.Contracts;

namespace MortalEngines.Core
{
    public class Engine : IEngine, IWriter
    {
        private readonly MachinesManager machinesManager;

        public Engine()
        {
            this.machinesManager = new MachinesManager();
        }

        public void Run()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Quit")
            {
                string[] commandArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string commandType = commandArgs[0];

                string contentToWrite = string.Empty;

                try
                {
                    switch (commandType)
                    {
                        case "HirePilot":
                            string pilotName = commandArgs[1];

                            contentToWrite = this.machinesManager.HirePilot(pilotName);
                            Write(contentToWrite);
                            break;
                        case "PilotReport":
                            string pilotNameForReport = commandArgs[1];

                            contentToWrite = this.machinesManager.PilotReport(pilotNameForReport);
                            Write(contentToWrite);
                            break;
                        case "ManufactureTank":
                            string tankName = commandArgs[1];
                            double tankAttack = double.Parse(commandArgs[2]);
                            double tankDefense = double.Parse(commandArgs[3]);

                            contentToWrite = this.machinesManager.ManufactureTank(tankName, tankAttack, tankDefense);
                            Write(contentToWrite);
                            break;
                        case "ManufactureFighter":
                            string fighterName = commandArgs[1];
                            double fighterAttack = double.Parse(commandArgs[2]);
                            double fighterDefense = double.Parse(commandArgs[3]);

                            contentToWrite = this.machinesManager.ManufactureFighter(fighterName, fighterAttack, fighterDefense);
                            Write(contentToWrite);
                            break;
                        case "MachineReport":
                            string machineName = commandArgs[1];

                            contentToWrite = this.machinesManager.MachineReport(machineName);
                            Write(contentToWrite);
                            break;
                        case "AggressiveMode":
                            string attackerName = commandArgs[1];

                            contentToWrite = this.machinesManager.ToggleFighterAggressiveMode(attackerName);
                            Write(contentToWrite);
                            break;
                        case "DefenseMode":
                            string defenderName = commandArgs[1];

                            contentToWrite = this.machinesManager.ToggleTankDefenseMode(defenderName);
                            Write(contentToWrite);
                            break;
                        case "Engage":
                            string pilotNameToEngage = commandArgs[1];
                            string machineNameToEngage = commandArgs[2];

                            contentToWrite = this.machinesManager.EngageMachine(pilotNameToEngage, machineNameToEngage);
                            Write(contentToWrite);
                            break;
                        case "Attack":
                            string attackingMachineName = commandArgs[1];
                            string defendingMachineName = commandArgs[2];

                            contentToWrite = this.machinesManager.AttackMachines(attackingMachineName, defendingMachineName);
                            Write(contentToWrite);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Write($"Error: {ex.Message}");
                }               
            }
        }

        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
}
