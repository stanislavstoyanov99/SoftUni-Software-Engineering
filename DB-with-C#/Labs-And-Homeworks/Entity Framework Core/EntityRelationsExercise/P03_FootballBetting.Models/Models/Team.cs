﻿namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Team
    {
        public int TeamId { get; set; }

        public string Name { get; set; }

        public string LogoUrl { get; set; }

        public string Initials { get; set; }

        public decimal Budget { get; set; }

        public int PrimaryKitColorId { get; set; }

        public Color PrimaryKitColor { get; set; }

        public int SecondaryKitColorId { get; set; }

        public Color SecondaryKitColor { get; set; }

        public int TownId { get; set; }

        public Town Town { get; set; }

        // Instead of Fluent API -> [InverseProperty("HomeTeam")]
        public ICollection<Game> HomeGames { get; set; }
            = new HashSet<Game>();

        // Instead of Fluent API -> [InverseProperty("AwayTeam")]
        public ICollection<Game> AwayGames { get; set; }
            = new HashSet<Game>();

        public ICollection<Player> Players { get; set; }
            = new HashSet<Player>();
    }
}
