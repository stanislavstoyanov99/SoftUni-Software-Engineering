﻿namespace IRunes.App.ViewModels.Albums
{
    using System.Collections.Generic;

    public class DetailsViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Cover { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<TrackInfoViewModel> Tracks { get; set; }
    }
}
