namespace MusicHub.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using AutoMapper;

    using Newtonsoft.Json;

    using Data;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter
            = "Imported {0}";

        private const string SuccessfullyImportedProducerWithPhone
            = "Imported {0} with phone: {1} produces {2} albums";

        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";

        private const string SuccessfullyImportedSong
            = "Imported {0} ({1} genre) with duration {2}";

        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            Writer[] writers = JsonConvert.DeserializeObject<Writer[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            foreach (var writer in writers)
            {
                bool isWriterValid = IsValid(writer);

                if (isWriterValid == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                context.Writers.Add(writer);

                sb.AppendLine(string.Format(SuccessfullyImportedWriter,
                    writer.Name));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producersDto = JsonConvert.DeserializeObject<ImportProducerDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            foreach (var producerDto in producersDto)
            {
                var producer = Mapper.Map<Producer>(producerDto);

                bool isProducerValid = IsValid(producer);

                if (isProducerValid == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                // Solution with LINQ

                //var albums = producerDto.ProducerAlbums
                //    .Select(a => Mapper.Map<Album>(a))
                //    .ToList();
                //bool hasInvalidAlbum = albums.Any(a => IsValid(a) == false);

                //if (hasInvalidAlbum == true)
                //{
                //    sb.AppendLine(ErrorMessage);
                //    continue;
                //}

                // Solution without LINQ

                List<Album> albumsToAdd = new List<Album>();

                bool invalidAlbum = false;

                foreach (var albumDto in producerDto.ProducerAlbums)
                {
                    var album = Mapper.Map<Album>(albumDto);

                    bool isAlbumValid = IsValid(album);

                    if (isAlbumValid == false)
                    {
                        invalidAlbum = true;
                        sb.AppendLine(ErrorMessage);
                        break;
                    }

                    albumsToAdd.Add(album);
                }

                // Skip the current producer, because there is invalid album
                if (invalidAlbum)
                {
                    continue;
                }

                producer.Albums = albumsToAdd;

                context.Producers.Add(producer);

                if (producer.PhoneNumber != null)
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithPhone,
                        producer.Name,
                        producer.PhoneNumber,
                        producer.Albums.Count));
                }
                else
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithNoPhone,
                           producer.Name,
                           producer.Albums.Count));
                }
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var rootAttribute = new XmlRootAttribute("Songs");
            var xmlSerialzer = new XmlSerializer(typeof(ImportSongDto[]), rootAttribute);

            using var stringReader = new StringReader(xmlString);

            var songsDto = (ImportSongDto[])xmlSerialzer.Deserialize(stringReader);

            StringBuilder sb = new StringBuilder();

            foreach (var songDto in songsDto)
            {
                bool isGenreValid = Enum.IsDefined(typeof(Genre), songDto.Genre);

                if (isGenreValid == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var album = context.Albums
                    .FirstOrDefault(a => a.Id == songDto.AlbumId);
                var writer = context.Writers
                    .FirstOrDefault(w => w.Id == songDto.WriterId);

                if (album == null || writer == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var song = new Song
                {
                    Name = songDto.Name,
                    Duration = TimeSpan.ParseExact(songDto.Duration, "c", CultureInfo.InvariantCulture),
                    CreatedOn = DateTime.ParseExact(songDto.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Genre = Enum.Parse<Genre>(songDto.Genre),
                    AlbumId = songDto.AlbumId,
                    WriterId = songDto.WriterId,
                    Price = songDto.Price
                };

                bool isSongValid = IsValid(song);

                if (isSongValid == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                context.Songs.Add(song);

                sb.AppendLine(string.Format(SuccessfullyImportedSong,
                    song.Name,
                    song.Genre,
                    song.Duration));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var rootAttribute = new XmlRootAttribute("Performers");
            var xmlSerializer = new XmlSerializer(typeof(ImportPerformerDto[]), rootAttribute);

            using var stringReader = new StringReader(xmlString);

            var performersDto = (ImportPerformerDto[])xmlSerializer.Deserialize(stringReader);

            StringBuilder sb = new StringBuilder();

            foreach (var performerDto in performersDto)
            {
                bool invalidSong = false;

                foreach (var songDto in performerDto.PerformerSongs)
                {
                    var song = context.Songs
                        .FirstOrDefault(s => s.Id == songDto.Id);

                    if (song == null)
                    {
                        invalidSong = true;
                        break;
                    }
                }

                if (invalidSong)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var performerSongs = performerDto.PerformerSongs
                    .Select(s => new SongPerformer
                    {
                        SongId = s.Id
                    })
                    .ToArray();

                var performer = new Performer
                {
                    FirstName = performerDto.FirstName,
                    LastName = performerDto.LastName,
                    Age = performerDto.Age,
                    NetWorth = performerDto.NetWorth,
                    PerformerSongs = performerSongs
                };

                bool isPerformerValid = IsValid(performer);

                if (isPerformerValid == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                context.Performers.Add(performer);

                sb.AppendLine(string.Format(SuccessfullyImportedPerformer,
                    performer.FirstName,
                    performer.PerformerSongs.Count));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(Object obj)
        {
            var validationContext = new ValidationContext(obj);

            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResult, true);
        }
    }
}