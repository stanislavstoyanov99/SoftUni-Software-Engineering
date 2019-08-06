namespace MXGP.Core
{
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;

    using MXGP.Core.Contracts;
    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IChampionshipController championshipController;
        public CommandInterpreter(IChampionshipController championshipController)
        {
            this.championshipController = championshipController;
        }
        public string Read(string[] inputArgs)
        {
            string[] commandArgs = inputArgs
                .Skip(1)
                .ToArray();

            string commandName = inputArgs[0];

            MethodInfo championshipMethod = typeof(ChampionshipController)
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

            string result = (string)championshipMethod.Invoke(this.championshipController, requiredParamters.ToArray());

            return result;
        }
    }
}
