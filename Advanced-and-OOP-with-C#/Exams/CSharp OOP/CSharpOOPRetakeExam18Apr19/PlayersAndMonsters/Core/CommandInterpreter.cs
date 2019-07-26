namespace PlayersAndMonsters.Core
{
    using System.Linq;
    using System.Collections.Generic;

    using PlayersAndMonsters.Core.Contracts;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IManagerController managerController;

        public CommandInterpreter(IManagerController managerController)
        {
            this.managerController = managerController;
        }

        public string Read(string[] inputArgs)
        {
            string[] commandArgs = inputArgs
                .Skip(1)
                .ToArray();

            string commandName = inputArgs[0];

            MethodInfo managerMethod = typeof(ManagerController)
                .GetMethod(commandName);

            List<object> requiredParamters = new List<object>();

            foreach (var argument in commandArgs)
            {
                if (int.TryParse(argument, out int parsedArgument))
                {
                    requiredParamters.Add(parsedArgument);

                    continue;
                }

                requiredParamters.Add(argument);
            }

            string result = (string)managerMethod.Invoke(this.managerController, requiredParamters.ToArray());

            return result;
        }
    }
}
