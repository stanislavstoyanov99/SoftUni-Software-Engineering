using System;
using System.Collections.Generic;
using System.Linq;
using _05FootballTeamGenerator.Exceptions;
using _05FootballTeamGenerator.Models;

namespace _05FootballTeamGenerator.Core
{
    public class ProgramRunner
    {
        private readonly IList<Team> teams;

        public ProgramRunner()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] tokens = input.Split(';');

                    string command = tokens[0];
                    string teamName = tokens[1];

                    if (command == "Team")
                    {
                        Team team = new Team(teamName);
                        this.teams.Add(team);
                    }
                    else if (command == "Add")
                    {
                        AddPlaerToTeam(tokens, teamName);
                    }
                    else if (command == "Remove")
                    {
                        RemovePlayerFromTeam(tokens, teamName);
                    }
                    else if (command == "Rating")
                    {
                        RatingTeam(teamName);
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
        }

        private void RatingTeam(string teamName)
        {
            ValidateTeamName(teamName);

            Team team = this.teams.First(t => t.Name == teamName);

            Console.WriteLine(team);
        }

        private void RemovePlayerFromTeam(string[] tokens, string teamName)
        {
            ValidateTeamName(teamName);

            string playerToRemove = tokens[2];

            Team team = this.teams.First(t => t.Name == teamName);
            team.RemovePlayer(playerToRemove);
        }

        private void AddPlaerToTeam(string[] tokens, string teamName)
        {
            ValidateTeamName(teamName);

            string playerName = tokens[2];
            Stat playerStat = CreateStat(tokens);

            Player player = new Player(playerName, playerStat);

            Team team = this.teams.FirstOrDefault(t => t.Name == teamName);

            team.AddPlayer(player);
        }

        private Stat CreateStat(string[] tokens)
        {
            int endurance = int.Parse(tokens[3]);
            int sprint = int.Parse(tokens[4]);
            int dribble = int.Parse(tokens[5]);
            int passing = int.Parse(tokens[6]);
            int shooting = int.Parse(tokens[7]);

            Stat playerStat = new Stat(endurance, sprint, dribble, passing, shooting);

            return playerStat;
        }

        private void ValidateTeamName(string name)
        {
            Team team = this.teams.FirstOrDefault(t => t.Name == name);

            if (team == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MissingTeamException, name));
            }
        }
    }
}
