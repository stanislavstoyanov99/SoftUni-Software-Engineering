﻿namespace VaporStore.DataProcessor.ExportDtos
{
    using System.Collections.Generic;

    public class ExportGameDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Developer { get; set; }

        public string Tags { get; set; }

        public int Players { get; set; }
    }
}
