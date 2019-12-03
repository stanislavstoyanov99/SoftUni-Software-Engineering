namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using AutoMapper;
    using Data;
    using MusicHub.Data.Models;
    using MusicHub.DataProcessor.ImportDtos;
    using Newtonsoft.Json;

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
            return null;
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            return null;
        }

        private static bool IsValid(Object obj)
        {
            var validationContext = new System.ComponentModel
                .DataAnnotations
                .ValidationContext(obj);

            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResult, true);
        }
    }
}