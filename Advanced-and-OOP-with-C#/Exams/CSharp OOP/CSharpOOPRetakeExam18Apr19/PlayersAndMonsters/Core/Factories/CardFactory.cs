namespace PlayersAndMonsters.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;

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
                throw new ArgumentNullException(ExceptionMessages.CardNotFoundException);
            }

            ICard card = (ICard)Activator.CreateInstance(cardType, name);

            return card;
        }
    }
}
