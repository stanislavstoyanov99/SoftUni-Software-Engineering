namespace MusicHub.DataProcessor.ImportDtos
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class ImportProducerDto
    {
        public string Name { get; set; }

        public string Pseudonym { get; set; }

        public string PhoneNumber { get; set; }

        [JsonProperty("Albums")]
        public ICollection<ImportAlbumDto> ProducerAlbums { get; set; }
    }
}
