namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var data = context.Genres.ToList()
                .Where(x => genreNames.Contains(x.Name))
                .Select(x => new
                {
                    Id = x.Id,
                    Genre = x.Name,
                    Games = x.Games
                    .Select(g => new
                    {
                        Id = g.Id,
                        Title = g.Name,
                        Developer = g.Developer.Name,
                        Tags = string.Join(", ", g.GameTags.Select(gt => gt.Tag.Name)),
                        Players = g.Purchases.Count()
                    })
                    .Where(g => g.Players > 0)
                    .OrderByDescending(g => g.Players)
                    .ThenBy(g => g.Id),
                    TotalPlayers = x.Games.Sum(x => x.Purchases.Count())
                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Genre);

            return JsonConvert.SerializeObject(data);
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            //var users =  context.Users.ToList()
            //      .Where(u => u.Cards.Any(p => p.Purchases.Any(g => g.Type.ToString() == storeType)))
            //      .Select(u => new UserPurchasesDTO
            //      {
            //          Username = u.Username,
            //          Purchases = u.Cards.SelectMany(p => p.Purchases)
            //          .Where(p => p.Type.ToString() == storeType)
            //              .Select(p => new PurchaseDTO
            //              {
            //                  Card = p.Card.Number,
            //                  Cvc = p.Card.Cvc,
            //                  Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
            //                  Game = new GameDTO
            //                  {
            //                      Title = p.Game.Name,
            //                      Genre = p.Game.Genre.Name,
            //                      Price = p.Game.Price,
            //                  }
            //              })
            //              .OrderBy(p => p.Date)
            //              .ToArray(),
            //          TotalSpent = u.Cards.Sum(c => c.Purchases.Count())
            //      })
            //      .OrderByDescending(u => u.TotalSpent).ThenBy(u => u.Username).ToArray();

            var users = context.Users.ToList()
                .Where(u => u.Cards.Any(c => c.Purchases.Any()))
                .OrderByDescending(u => u.Cards.Sum(c => c.Purchases.Sum(p => p.Game.Price)))
                .ThenBy(u => u.Username)
                .Select(u => new UserPurchasesDTO
                {
                    Username = u.Username,
                    Purchases = u.Cards
                        .SelectMany(c => c.Purchases)
                        .OrderBy(p => p.Date)
                        .Select(p => new PurchaseDTO
                        {
                            Card = p.Card.Number,
                            Cvc = p.Card.Cvc,
                            Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game = new GameDTO
                            {
                                Title = p.Game.Name,
                                Genre = p.Game.Genre.Name,
                                Price = p.Game.Price
                            }
                        }).ToArray(),
                    TotalSpent = u.Cards
                        .SelectMany(c => c.Purchases)
                        .Sum(p => p.Game.Price)
                }).ToArray();

            var serializer = new XmlSerializer(typeof(UserPurchasesDTO[]),
                new XmlRootAttribute("Users"));

            var strWriter = new StringWriter();
            serializer.Serialize(strWriter,users);
            return strWriter.ToString();
        }
    }
}