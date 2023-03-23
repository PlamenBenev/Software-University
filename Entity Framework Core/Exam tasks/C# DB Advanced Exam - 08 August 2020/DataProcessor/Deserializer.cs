namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var games = JsonConvert.DeserializeObject<IEnumerable<GameJsonImportModels>>(jsonString);

            foreach (var json in games)
            {
                if (!IsValid(json) || json.Tags.Length == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var genre = context.Genres.FirstOrDefault(x => x.Name == json.Genre)
                    ?? new Genre { Name = json.Genre };
                var developer = context.Developers.FirstOrDefault(x => x.Name == json.Developer)
                    ?? new Developer { Name = json.Developer };

                var game = new Game
                {
                    Name = json.Name,
                    Genre = genre,
                    Developer = developer,
                    Price = json.Price,
                    ReleaseDate = (DateTime)json.ReleaseDate,
                };

                foreach (var gameTag in json.Tags)
                {
                    var tag = context.Tags.FirstOrDefault(x => x.Name == gameTag)
                    ?? new Tag { Name = gameTag };

                    game.GameTags.Add(new GameTag { Tag = tag });
                }

                context.Games.Add(game);
                context.SaveChanges();
                sb.AppendLine($"Added {json.Name} ({json.Genre}) with {json.Tags.Length} tags");
            }


            return sb.ToString();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var users = JsonConvert.DeserializeObject<IEnumerable<UserImportDto>>(jsonString);

            foreach (var json in users)
            {
                if (!IsValid(json))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var user = new User
                {
                    Username = json.Username,
                    FullName = json.FullName,
                    Email = json.Email,
                    Age = json.Age,
                    Cards = json.Cards.Select(x => new Card
                    {
                        Number = x.Number,
                        Cvc = x.Cvc,
                        Type = x.Type.Value
                    }).ToList(),
                };

                context.Add(user);
                context.SaveChanges();
                sb.AppendLine($"Imported {json.Username} with {json.Cards.Count()} cards");
            }

            return sb.ToString().Trim();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var xmlSer = new XmlSerializer(typeof(PurchasesImportXmlDto[]),
                new XmlRootAttribute("Purchases"));
            var purchases = (PurchasesImportXmlDto[])xmlSer
                .Deserialize(new StringReader(xmlString));

            foreach (var item in purchases)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var validedDate = DateTime
                    .TryParseExact(item.Date, "dd/MM/yyyy HH:mm",
                    CultureInfo.InvariantCulture ,
                    DateTimeStyles.None,
                    out var date); 

                if (!validedDate)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var purchase = new Purchase
                {
                    Type = item.Type,
                    ProductKey = item.Key,
                    Date = date,
                };

                purchase.Card = context.Cards.FirstOrDefault(x => x.Number == item.Card);
                purchase.Game = context.Games.FirstOrDefault(x => x.Name == item.Title);
                var username = context.Users.Where(x => x.Id == purchase.Card.UserId).FirstOrDefault();

                context.Purchases.Add( purchase );
                sb.AppendLine($"Imported {item.Title} for {username.Username}");
            }


                context.SaveChanges();
            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}