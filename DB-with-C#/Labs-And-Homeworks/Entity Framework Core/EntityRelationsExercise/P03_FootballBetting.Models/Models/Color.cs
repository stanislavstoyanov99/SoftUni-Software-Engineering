﻿namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Color
    {
        public int ColorId { get; set; }

        public string Name { get; set; }

        // Instead of Fluent API -> [InverseProperty("PrimaryKitColor")]
        public ICollection<Team> PrimaryKitTeams { get; set; }
            = new HashSet<Team>();

        // Instead of Fluent API -> [InverseProperty("SecondaryKitColor")]
        public ICollection<Team> SecondaryKitTeams { get; set; }
            = new HashSet<Team>();
    }
}
