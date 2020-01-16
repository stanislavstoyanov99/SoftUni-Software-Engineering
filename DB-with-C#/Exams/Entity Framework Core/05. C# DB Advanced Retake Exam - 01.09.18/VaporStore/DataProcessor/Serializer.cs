namespace VaporStore.DataProcessor
{
    using System.IO;
    using System.Xml;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Xml.Serialization;

    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    using Data;
    using VaporStore.DataProcessor.ExportDtos;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
            var gamesByGenres = context.Genres
                .Where(g => genreNames.Any(gn => gn.Contains(g.Name)))
                .Select(g => new ExportGenreDto
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games
                        .Where(g => g.Purchases.Count != 0)
                        .Select(game => new ExportGameDto
                        {
                            Id = game.Id,
                            Title = game.Name,
                            Developer = game.Developer.Name,
                            Tags = string.Join(", ", game.GameTags
                                .Select(gt => gt.Tag.Name)),
                            Players = game.Purchases.Count
                        })
                        .OrderByDescending(ga => ga.Players)
                        .ThenBy(ga => ga.Id)
                        .ToArray(),
                    TotalPlayers = g.Games
                        .Sum(g => g.Purchases.Count)
                })
                .OrderByDescending(g => g.TotalPlayers)
                .ThenBy(g => g.Id)
                .ToArray();

            string jsonExport = JsonConvert.SerializeObject(gamesByGenres, Formatting.Indented);

            return jsonExport;
        }

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
            var users = context.Users
                .Select(u => new ExportUserDto
                {
                    Username = u.Username,
                    Purchases = u.Cards
                        .SelectMany(c => c.Purchases)
                            .Where(p => p.Type.ToString() == storeType)
                            .Select(p => new ExportPurchaseDto
                            {
                                Card = p.Card.Number,
                                Cvc = p.Card.Cvc,
                                Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                                Game = new ExportPurchaseGameDto
                                {
                                    Title = p.Game.Name,
                                    Genre = p.Game.Genre.Name,
                                    Price = p.Game.Price
                                }
                            })
                            .OrderBy(p => p.Date)
                            .ToArray(),
                    TotalSpent = u.Cards
                        .Sum(c => c.Purchases
                            .Where(p => p.Type.ToString() == storeType)
                            .Sum(p => p.Game.Price))
                })
                .Where(u => u.Purchases.Any())
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToArray();

            var rootAttribute = new XmlRootAttribute("Users");
            var xmlSerializer = new XmlSerializer(typeof(ExportUserDto[]), rootAttribute);

            StringBuilder sb = new StringBuilder();

            using var stringWriter = new StringWriter(sb);

            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(stringWriter, users, xmlNamespaces);

            return sb.ToString().TrimEnd();
        }
	}
}