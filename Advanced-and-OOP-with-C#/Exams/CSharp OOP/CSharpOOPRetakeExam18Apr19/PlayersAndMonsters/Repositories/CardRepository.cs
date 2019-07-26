using System;
using System.Linq;
using System.Collections.Generic;

using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly List<ICard> cards;

        public CardRepository()
        {
            this.cards = new List<ICard>();
        }

        public int Count => this.Cards.Count;

        public IReadOnlyCollection<ICard> Cards => this.cards.AsReadOnly();

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException(ExceptionMessages.CardNotFoundException);
            }

            bool isCardExists = this.cards.Any(p => p.Name == card.Name);

            if (isCardExists)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CardAllreadyExistsException,
                    card.Name));
            }

            this.cards.Add(card);
        }

        public ICard Find(string name)
        {
            ICard card = this.cards
                .FirstOrDefault(p => p.Name == name);

            if (card == null)
            {
                throw new ArgumentException(ExceptionMessages.CardNotFoundException);
            }

            return card;
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException(ExceptionMessages.CardNotFoundException);
            }

            return this.cards.Remove(card);
        }
    }
}
