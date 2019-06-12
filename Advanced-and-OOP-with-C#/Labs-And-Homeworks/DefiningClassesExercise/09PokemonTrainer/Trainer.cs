using System.Collections.Generic;

namespace DefiningClasses
{
    public class Trainer
    {
        private const int DefaultValueNumberOfBadges = 0;

        public Trainer(string name)
        {
            Name = name;
            NumberOfBadges = DefaultValueNumberOfBadges;
            Pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }

        public int NumberOfBadges { get; set; } 

        public List<Pokemon> Pokemons { get; set; }

        public override string ToString()
        {
            return $"{Name} {NumberOfBadges} {Pokemons.Count}";
        }
    }
}
