using System;
using System.Linq;
using System.Collections.Generic;

using _08MilitaryElite.Exceptions;
using _08MilitaryElite.Interfaces;
using _08MilitaryElite.Models;
using _08MilitaryElite.Factories;

namespace _08MilitaryElite.Core
{
    public class Engine
    {
        private readonly List<ISoldier> army;

        private readonly SoldierFactory soldierFactory;
        //private readonly LieutenantGeneralFactory generalFactory;
        //private readonly EngineerFactory engineerFactory;
        //private readonly CommandoFactory commandoFactory;
        //private readonly SpyFactory spyFactory;

        public Engine()
        {
            this.army = new List<ISoldier>();

            //this.privateFactory = new PrivateFactory();
            //this.generalFactory = new LieutenantGeneralFactory();
            //this.engineerFactory = new EngineerFactory();
            //this.commandoFactory = new CommandoFactory();
            //this.spyFactory = new SpyFactory();
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] soldierInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string soldierType = soldierInfo[0];
                string id = soldierInfo[1];
                string firstName = soldierInfo[2];
                string lastName = soldierInfo[3];
                decimal salary = decimal.Parse(soldierInfo[4]);

                SoldierFactory soldierFactory = null;

                if (soldierType == "Private")
                {
                    soldierFactory = new PrivateFactory(id, firstName, lastName, salary);
                    ISoldier soldier = soldierFactory.GetSoldier();

                    this.army.Add(soldier);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    ILieutenantGeneral lieutenantGeneral = this.generalFactory.CreateLieutenantGeneral(id, firstName, lastName, salary);

                    string[] privates = soldierInfo
                        .Skip(5)
                        .ToArray();

                    AddSoldier(lieutenantGeneral, privates);

                    this.army.Add(lieutenantGeneral);
                }
                else if (soldierType == "Engineer")
                {
                    try
                    {
                        string corps = soldierInfo[5];

                        IEngineer engineer = this.engineerFactory.CreateEngineer(id, firstName, lastName, salary, corps);

                        string[] repairs = soldierInfo
                            .Skip(6)
                            .ToArray();

                        AddRepair(engineer, repairs);

                        this.army.Add(engineer);
                    }
                    catch (InvalidCorpsException ice)
                    {

                    }
                }
                else if (soldierType == "Commando")
                {
                    try
                    {
                        string corps = soldierInfo[5];

                        ICommando commando = this.commandoFactory.CreateCommando(id, firstName, lastName, salary, corps);

                        string[] missions = soldierInfo
                            .Skip(6)
                            .ToArray();

                        AddMission(commando, missions);

                        this.army.Add(commando);
                    }
                    catch (InvalidCorpsException ice)
                    {

                    }
                }
                else if (soldierType == "Spy")
                {
                    int codeNumber = (int)salary;

                    ISpy spy = this.spyFactory.CreateSpy(id, firstName, lastName, codeNumber);

                    this.army.Add(spy);
                }
            }

            PrintArmy();
        }

        private void PrintArmy()
        {
            foreach (var soldier in this.army)
            {
                Type type = soldier.GetType();
                Object actual = Convert.ChangeType(soldier, type);

                Console.WriteLine(actual);
            }
        }

        private void AddSoldier(ILieutenantGeneral lieutenantGeneral, string[] privates)
        {
            foreach (var soldierId in privates)
            {
                ISoldier soldierToAdd = this.army
                     .First(s => s.Id == soldierId);

                lieutenantGeneral.AddPrivate(soldierToAdd);
            }
        }

        private void AddMission(ICommando commando, string[] missions)
        {
            for (int i = 0; i < missions.Length; i += 2)
            {
                try
                {
                    string codeName = missions[i];
                    string state = missions[i + 1];

                    IMission mission = new Mission(codeName, state);

                    commando.AddMission(mission);
                }
                catch (InvalidStateException ise)
                {
                    continue;
                }
                catch (InvalidMissionStatus ims)
                {
                    continue;
                }
            }
        }

        private void AddRepair(IEngineer engineer, string[] repairs)
        {
            for (int i = 0; i < repairs.Length; i += 2)
            {
                string partName = repairs[i];
                int hoursWorked = int.Parse(repairs[i + 1]);

                IRepair repair = new Repair(partName, hoursWorked);

                engineer.AddRepair(repair);
            }
        }
    }
}
