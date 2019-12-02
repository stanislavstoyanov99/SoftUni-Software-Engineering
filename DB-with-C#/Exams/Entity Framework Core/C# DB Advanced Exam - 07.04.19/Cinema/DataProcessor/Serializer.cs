namespace Cinema.DataProcessor
{
    using System.IO;
    using System.Xml;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using Data;
    using Cinema.DataProcessor.ExportDto;

    using Newtonsoft.Json;
    using System;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var topMovies = context.Movies
                .Where(m => m.Rating >= rating && m.Projections
                    .Any(p => p.Tickets.Any()))
                .OrderByDescending(m => m.Rating)
                .ThenByDescending(m => m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)))
                .Take(10)
                .Select(m => new ExportMoviesDto
                {
                    MovieName = m.Title,
                    Rating = m.Rating.ToString("F2"),
                    TotalIncomes = m.Projections
                        .Sum(p => p.Tickets
                            .Sum(t => t.Price)).ToString("F2"),
                    Customers = m.Projections
                        .SelectMany(p => p.Tickets)
                            .Select(c => new ExportCustomersDto
                            {
                                FirstName = c.Customer.FirstName,
                                LastName = c.Customer.LastName,
                                Balance = c.Customer.Balance.ToString("F2")
                            })
                            .OrderByDescending(c => c.Balance)
                            .ThenBy(c => c.FirstName)
                            .ThenBy(c => c.LastName)
                            .ToArray()
                })
                .ToArray();

            string jsonExport = JsonConvert.SerializeObject(topMovies, Newtonsoft.Json.Formatting.Indented);

            return jsonExport;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var topCustomers = context.Customers
                .Where(c => c.Age >= age)
                .OrderByDescending(c => c.Tickets.Sum(t => t.Price))
                .Take(10)
                .Select(c => new ExportTopCustomersDto
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    SpentMoney = c.Tickets.Sum(t => t.Price).ToString("F2"),
                    SpentTime = TimeSpan.FromMilliseconds(c.Tickets
                        .Sum(t => t.Projection.Movie.Duration.TotalMilliseconds))
                            .ToString(@"hh\:mm\:ss")
                })
                .ToArray();

            var rootAttribute = new XmlRootAttribute("Customers");
            var xmlSerializer = new XmlSerializer(typeof(ExportTopCustomersDto[]), rootAttribute);

            StringBuilder sb = new StringBuilder();

            using var stringWriter = new StringWriter(sb);

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(stringWriter, topCustomers, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}