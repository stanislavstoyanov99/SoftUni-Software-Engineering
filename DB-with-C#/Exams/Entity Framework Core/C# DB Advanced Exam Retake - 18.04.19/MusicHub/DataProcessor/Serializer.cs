namespace MusicHub.DataProcessor
{
    using System.IO;
    using System.Xml;
    using System.Text;
    using System.Linq;
    using System.Globalization;
    using System.Xml.Serialization;

    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    using Data;
    using MusicHub.DataProcessor.ExportDtos;

    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .Where(a => a.ProducerId == producerId)
                .OrderByDescending(a => a.Songs.Sum(a => a.Price))
                .Select(a => new ExportAlbumInfoDto
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                        .Select(s => new ExportAlbumSongDto
                        {
                            SongName = s.Name,
                            Price = s.Price.ToString("F2"),
                            Writer = s.Writer.Name
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.Writer)
                        .ToArray(),
                    AlbumPrice = a.Songs
                        .Sum(a => a.Price)
                        .ToString("F2")
                })
                .ToArray();

            string jsonExport = JsonConvert.SerializeObject(albums, Formatting.Indented);

            return jsonExport;
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new ExportSongDto
                {
                    SongName = s.Name,
                    Writer = s.Writer.Name,
                    Performer = s.SongPerformers
                        .Select(s => s.Performer.FirstName + " " + s.Performer.LastName)
                        .FirstOrDefault(),
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c", CultureInfo.InvariantCulture)
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.Writer)
                .ThenBy(s => s.Performer)
                .ToArray();

            var rootAttribute = new XmlRootAttribute("Songs");
            var xmlSerializer = new XmlSerializer(typeof(ExportSongDto[]), rootAttribute);

            StringBuilder sb = new StringBuilder();
            using var stringWriter = new StringWriter(sb);

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(stringWriter, songs, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}