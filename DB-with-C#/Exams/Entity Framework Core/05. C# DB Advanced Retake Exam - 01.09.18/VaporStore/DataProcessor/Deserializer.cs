namespace VaporStore.DataProcessor
{
	using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;

    using Data;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.ImportDtos;
    using VaporStore.Data.Models.Enumerations;
    using Microsoft.EntityFrameworkCore;

    public static class Deserializer
	{
        private const string ErrorMessage = "Invalid Data";
        private const string SuccessfullyAddedGame = "Added {0} ({1}) with {2} tags";
        private const string SuccessfullyAddedCard = "Imported {0} with {1} cards";
        private const string SuccessfullyAddedPurchase = "Imported {0} for {1}";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
            var gamesDto = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            foreach (var gameDto in gamesDto)
            {
                bool isGameDtoValid = IsValid(gameDto);

                if (isGameDtoValid == false || gameDto.Tags.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var developer = context.Developers
                    .FirstOrDefault(d => d.Name == gameDto.Developer);
                var genre = context.Genres
                    .FirstOrDefault(g => g.Name == gameDto.Genre);

                developer = GetOrCreateDeveloper(context, developer, gameDto);
                genre = GetOrCreateGenre(context, genre, gameDto);

                // Create tags
                var tags = new List<Tag>();

                foreach (var tagName in gameDto.Tags)
                {
                    var tagToAdd = context.Tags
                        .FirstOrDefault(t => t.Name == tagName);

                    if (tagToAdd == null)
                    {
                        tagToAdd = new Tag
                        {
                            Name = tagName
                        };

                        context.Tags.Add(tagToAdd);
                    }

                    tags.Add(tagToAdd);
                }

                // Create successfully game
                var game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = DateTime
                        .ParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Developer = developer,
                    Genre = genre,
                    GameTags = tags
                        .Select(t => new GameTag { Tag = t }).ToArray()
                };

                context.Games.Add(game);
                context.SaveChanges();

                sb.AppendLine(String.Format(SuccessfullyAddedGame,
                    game.Name,
                    game.Genre.Name,
                    game.GameTags.Count));
            }

            return sb.ToString().TrimEnd();
		}

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
            var usersDto = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            foreach (var userDto in usersDto)
            {
                bool isUserDtoValid = IsValid(userDto);
                bool areCardsValid = userDto.Cards
                    .Any(c => IsValid(c));

                if (isUserDtoValid == false || areCardsValid == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                List<Card> userCards = new List<Card>();

                foreach (var cardDto in userDto.Cards)
                {
                    var card = new Card
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.CVC,
                        Type = Enum.Parse<CardType>(cardDto.Type)
                    };

                    userCards.Add(card);
                }

                var user = new User
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age,
                    Cards = userCards
                };

                context.Users.Add(user);

                sb.AppendLine(String.Format(SuccessfullyAddedCard,
                    user.Username,
                    user.Cards.Count));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
            var rootAttribute = new XmlRootAttribute("Purchases");
            var xmlSerializer = new XmlSerializer(typeof(ImportPurchaseDto[]), rootAttribute);

            using var stringReader = new StringReader(xmlString);

            var purchasesDto = (ImportPurchaseDto[])xmlSerializer.Deserialize(stringReader);

            StringBuilder sb = new StringBuilder();

            foreach (var purchaseDto in purchasesDto)
            {
                bool isPurchaseTypeValid = Enum.IsDefined(typeof(PurchaseType), purchaseDto.Type);
                bool isPurchaseDtoValid = IsValid(purchasesDto);

                var purchaseGame = context.Games
                    .FirstOrDefault(g => g.Name == purchaseDto.Title);
                var purchaseCard = context.Cards
                    .Include(c => c.User)
                    .Single(c => c.Number == purchaseDto.Card);

                if (isPurchaseTypeValid == false ||
                    isPurchaseDtoValid == false || 
                    purchaseGame == null ||
                    purchaseCard == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                var purchase = new Purchase
                {
                    Type = Enum.Parse<PurchaseType>(purchaseDto.Type),
                    ProductKey = purchaseDto.Key,
                    Game = purchaseGame,
                    Card = purchaseCard,
                    Date = DateTime.ParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                };

                context.Purchases.Add(purchase);

                sb.AppendLine(String.Format(SuccessfullyAddedPurchase,
                    purchase.Game.Name,
                    purchase.Card.User.Username));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid (Object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);

            return isValid;
        }

        private static Genre GetOrCreateGenre(VaporStoreDbContext context, Genre genre, ImportGameDto gameDto)
        {
            if (genre == null)
            {
                genre = new Genre
                {
                    Name = gameDto.Genre
                };

                context.Genres.Add(genre);
            }

            return genre;
        }

        private static Developer GetOrCreateDeveloper(VaporStoreDbContext context, Developer developer, ImportGameDto gameDto)
        {
            if (developer == null)
            {
                developer = new Developer
                {
                    Name = gameDto.Developer
                };

                context.Developers.Add(developer);
            }

            return developer;
        }
	}
}