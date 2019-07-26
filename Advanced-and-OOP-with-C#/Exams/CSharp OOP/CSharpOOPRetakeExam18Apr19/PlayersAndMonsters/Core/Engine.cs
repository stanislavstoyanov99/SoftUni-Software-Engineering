using System;
using System.Text;

using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO.Contracts;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private readonly IManagerController managerController;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IManagerController managerController, IReader reader, IWriter writer)
        {
            this.managerController = managerController;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string input = string.Empty;

            while ((input = this.reader.ReadLine()) != "Exit")
            {
                string[] commandArgs = input.Split(" ");
                string commandType = commandArgs[0];
                string resultMessage = string.Empty;

                StringBuilder sb = new StringBuilder();

                try
                {
                    switch (commandType)
                    {
                        case "AddPlayer":
                            string playerType = commandArgs[1];
                            string playerUsername = commandArgs[2];

                            resultMessage = this.managerController.AddPlayer(playerType, playerUsername);
                            sb.AppendLine(resultMessage);
                            break;
                        case "AddCard":
                            string cardType = commandArgs[1];
                            string cardName = commandArgs[2];

                            resultMessage = this.managerController.AddCard(cardType, cardName);
                            sb.AppendLine(resultMessage);
                            break;
                        case "AddPlayerCard":
                            string username = commandArgs[1];
                            string cardNameToAdd = commandArgs[2];

                            resultMessage = this.managerController.AddPlayerCard(username, cardNameToAdd);
                            sb.AppendLine(resultMessage);
                            break;
                        case "Fight":
                            string attackUser = commandArgs[1];
                            string enemyUser = commandArgs[2];

                            resultMessage = this.managerController.Fight(attackUser, enemyUser);
                            sb.AppendLine(resultMessage);
                            break;
                        case "Report":
                            resultMessage = this.managerController.Report();
                            sb.AppendLine(resultMessage);
                            break;
                    }

                    this.writer.Write(sb.ToString());
                }
                catch (Exception ex)
                {
                    sb.AppendLine(ex.Message);
                }
            }
        }
    }
}
