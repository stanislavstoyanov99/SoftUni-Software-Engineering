namespace MusicHub.DataProcessor.ExportDtos
{
    public class ExportAlbumInfoDto
    {
        public string AlbumName { get; set; }

        public string ReleaseDate { get; set; }

        public string ProducerName { get; set; }

        public ExportAlbumSongDto[] Songs { get; set; }

        public string AlbumPrice { get; set; }
    }
}
