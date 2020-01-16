﻿namespace Cinema.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;

    public class ImportHallWithSeatsDto
    {
        public string Name { get; set; }

        public bool Is4Dx { get; set; }

        public bool Is3D { get; set; }

        [JsonProperty("Seats")]
        [Range(1, int.MaxValue)]
        public int SeatsCount { get; set; }
    }
}
