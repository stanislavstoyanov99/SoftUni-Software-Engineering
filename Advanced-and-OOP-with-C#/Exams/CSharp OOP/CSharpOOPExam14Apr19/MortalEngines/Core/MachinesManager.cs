namespace MortalEngines.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities.Models;
    using MortalEngines.Entities.Contracts;

    public class MachinesManager : IMachinesManager
    {
        private readonly List<IPilot> pilots;
        private readonly List<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            string result = string.Empty;

            bool isFound = this.pilots.Any(p => p.Name == name);

            if (!isFound)
            {
                IPilot pilot = new Pilot(name);
                pilots.Add(pilot);

                result = string.Format(OutputMessages.PilotHired, name);
            }
            else
            {
                result = string.Format(OutputMessages.PilotExists, name);
            }

            return result;
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            string result = string.Empty;

            bool isFound = this.machines
                .Any(m => m.Name == name && m.GetType().Name == nameof(Tank));

            if (!isFound)
            {
                IMachine tank = new Tank(name, attackPoints, defensePoints);
                this.machines.Add(tank);

                result = string.Format(OutputMessages.TankManufactured,
                    tank.Name,
                    tank.AttackPoints,
                    tank.DefensePoints);
            }
            else
            {
                result = string.Format(OutputMessages.MachineExists, name);
            }

            return result;
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            string result = string.Empty;

            bool isFound = this.machines
                .Any(f => f.Name == name && f.GetType().Name == nameof(Fighter));

            if (!isFound)
            {
                IFighter fighter = new Fighter(name, attackPoints, defensePoints);
                this.machines.Add(fighter);

                result = string.Format(OutputMessages.FighterManufactured,
                    fighter.Name,
                    fighter.AttackPoints,
                    fighter.DefensePoints,
                    fighter.AggressiveMode == true ? "ON" : "OFF");
            }
            else
            {
                result = string.Format(OutputMessages.MachineExists, name);
            }

            return result;
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            IPilot foundPilot = this.pilots
                .FirstOrDefault(p => p.Name == selectedPilotName);

            IMachine foundMachine = this.machines
                .FirstOrDefault(p => p.Name == selectedMachineName);

            if (foundPilot == null)
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }

            if (foundMachine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }

            if (foundMachine.Pilot != null)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, foundMachine.Name);
            }
            else
            {
                foundPilot.AddMachine(foundMachine);
                foundMachine.Pilot = foundPilot;

                return string.Format(OutputMessages.MachineEngaged, foundPilot.Name, foundMachine.Name);
            }
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine attackingMachine = this.machines
                .FirstOrDefault(m => m.Name == attackingMachineName);

            IMachine defendingMachine = this.machines
                .FirstOrDefault(m => m.Name == defendingMachineName);

            if (attackingMachine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }

            if (defendingMachine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }

            if (attackingMachine.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }

            if (defendingMachine.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
            }

            attackingMachine.Attack(defendingMachine);

            return string.Format(OutputMessages.AttackSuccessful,
                defendingMachine.Name, attackingMachine.Name, defendingMachine.HealthPoints);
        }

        public string PilotReport(string pilotReporting)
        {
            IPilot foundPilot = this.pilots
                .FirstOrDefault(p => p.Name == pilotReporting);

            return foundPilot.Report();
        }

        public string MachineReport(string machineName)
        {
            IMachine foundMachine = this.machines
                .FirstOrDefault(m => m.Name == machineName);

            return foundMachine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            string result = string.Empty;

            IMachine foundFighter = this.machines
                .FirstOrDefault(t => t.Name == fighterName &&
                t.GetType().Name == nameof(Fighter));

            if (foundFighter != null)
            {
                IFighter currentFighter = (IFighter)foundFighter;
                currentFighter.ToggleAggressiveMode();

                result = string.Format(OutputMessages.FighterOperationSuccessful, currentFighter.Name);
            }
            else
            {
                result = string.Format(OutputMessages.MachineNotFound, fighterName);
            }

            return result;
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            string result = string.Empty;

            IMachine foundTank = this.machines
                .FirstOrDefault(t => t.Name == tankName &&
                t.GetType().Name == nameof(Tank));

            if (foundTank != null)
            {
                ITank currentTank = (ITank)foundTank;
                currentTank.ToggleDefenseMode();

                result = string.Format(OutputMessages.TankOperationSuccessful, foundTank.Name);
            }
            else
            {
                result = string.Format(OutputMessages.MachineNotFound, tankName);
            }

            return result;
        }
    }
}