namespace PersonsInfo.Core
{
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private List<Person> players;
        private readonly Team team;

        public Engine()
        {
            this.players = new List<Person>();
            this.team = new Team("SoftUni");
        }

        public void Run()
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] playerInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                AddPlayerToPlayers(playerInfo);
            }

            AddPlayersToTeam();

            PrintTeamSizes();
        }

        private void PrintTeamSizes()
        {
            Console.WriteLine(this.team);
        }

        private void AddPlayersToTeam()
        {
            foreach (var player in players)
            {
                this.team.AddPlayer(player);
            }
        }

        private void AddPlayerToPlayers(string[] playerInfo)
        {
            string firstName = playerInfo[0];
            string lastName = playerInfo[1];
            int age = int.Parse(playerInfo[2]);
            decimal salary = decimal.Parse(playerInfo[3]);

            Person player = new Person(firstName, lastName, age, salary);
            players.Add(player);
        }
    }
}
