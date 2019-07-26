using System;
using System.Linq;
using System.Reflection;

using PlayersAndMonsters.Common;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Core.Factories
{
    public class CardFactory : ICardFactory
    {
        private const string SUFFIX = "Card";

        public ICard CreateCard(string type, string name)
        {
            Type cardType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(p => p.Name == type + SUFFIX);

            if (cardType == null)
            {
                throw new ArgumentException(ExceptionMessages.CardNotFoundException);
            }

            ICard card = (ICard)Activator.CreateInstance(cardType, name);

            return card;
        }
    }
}
