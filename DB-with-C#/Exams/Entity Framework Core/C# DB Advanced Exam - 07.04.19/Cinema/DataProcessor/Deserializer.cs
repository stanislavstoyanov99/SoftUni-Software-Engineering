namespace Cinema.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using Newtonsoft.Json;

    using Data;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";

        private const string SuccessfulImportHallSeat 
            = "Successfully imported {0}({1}) with {2} seats!";

        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";

        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            Movie[] movies = JsonConvert.DeserializeObject<Movie[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            foreach (var movie in movies)
            {
                bool isValidGenre = Enum.IsDefined(typeof(Genre), movie.Genre);
                bool isMovieTitleExists = context.Movies
                    .Any(m => m.Title == movie.Title);

                if (isValidGenre == false || isMovieTitleExists == true)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isMovieValid = IsValid(movie);

                if (isMovieValid == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                context.Movies.Add(movie);

                sb.AppendLine(string.Format(SuccessfulImportMovie,
                    movie.Title,
                    movie.Genre.ToString(),
                    movie.Rating.ToString("F2")));
            }

            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            ImportHallWithSeatsDto[] hallsDto = JsonConvert.DeserializeObject<ImportHallWithSeatsDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            foreach (var hallDto in hallsDto)
            {
                bool isHallDtoValid = IsValid(hallDto);

                Hall hall = Mapper.Map<Hall>(hallDto);
                bool isHallValid = IsValid(hall);

                if (isHallDtoValid == false || isHallValid == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                // Fill seats table with seat for the current hall
                for (int i = 0; i < hallDto.SeatsCount; i++)
                {
                    hall.Seats.Add(new Seat());
                }

                context.Halls.Add(hall);

                string projectionType = string.Empty;

                if (hall.Is3D == true && hall.Is4Dx == true)
                {
                    projectionType = "4Dx/3D";
                }
                else if (hall.Is3D == true && hall.Is4Dx == false)
                {
                    projectionType = "3D";
                }
                else if (hall.Is3D == false && hall.Is4Dx == true)
                {
                    projectionType = "4Dx";
                }
                else if (hall.Is3D == false && hall.Is4Dx == false)
                {
                    projectionType = "Normal";
                }

                sb.AppendLine(string.Format(SuccessfulImportHallSeat,
                    hall.Name,
                    projectionType,
                    hall.Seats.Count));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var rootAttribute = new XmlRootAttribute("Projections");
            var xmlSerializer = new XmlSerializer(typeof(ImportProjectionsDto[]), rootAttribute);

            using var stringReader = new StringReader(xmlString);

            var projectionsDto = (ImportProjectionsDto[])xmlSerializer
                .Deserialize(stringReader);

            StringBuilder sb = new StringBuilder();

            foreach (var projectionDto in projectionsDto)
            {
                var projection = Mapper.Map<Projection>(projectionDto);

                bool isProjectionValid = IsValid(projection);

                var hall = context.Halls.FirstOrDefault(h => h.Id == projection.HallId);
                var movie = context.Movies.FirstOrDefault(m => m.Id == projection.MovieId);

                if (isProjectionValid == false || hall == null || movie == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                context.Projections.Add(projection);

                sb.AppendLine(string.Format(SuccessfulImportProjection,
                    projection.Movie.Title,
                    projection.DateTime.ToString("MM/dd/yyyy")));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var rootAttribute = new XmlRootAttribute("Customers");
            var xmlSerializer = new XmlSerializer(typeof(ImportCustomersDto[]), rootAttribute);

            using var stringReader = new StringReader(xmlString);

            var customersDto = (ImportCustomersDto[])xmlSerializer.Deserialize(stringReader);

            StringBuilder sb = new StringBuilder();

            foreach (var customerDto in customersDto)
            {
                var customer = Mapper.Map<Customer>(customerDto);

                bool isCustomerValid = IsValid(customer);

                if (isCustomerValid == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customerTicketsDto = customerDto.Tickets;

                foreach (var ticketDto in customerTicketsDto)
                {
                    var ticket = Mapper.Map<Ticket>(ticketDto);

                    bool isTicketValid = IsValid(ticket);

                    if (isTicketValid == false)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var projection = context.Projections
                        .FirstOrDefault(p => p.Id == ticket.ProjectionId);

                    if (projection == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                }

                context.Customers.Add(customer);

                sb.AppendLine(string.Format(SuccessfulImportCustomerTicket,
                    customer.FirstName,
                    customer.LastName,
                    customer.Tickets.Count));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);

            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResult, true);
        }
    }
}