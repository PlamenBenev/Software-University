namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var albumsInfo = context.Albums
                .Where(x => x.ProducerId.HasValue && x.ProducerId.Value == producerId)
                .ToArray()
                .OrderByDescending(x => x.Price)
                .Select(x => new
                {
                    x.Name,
                    releaseDate =
                     x.ReleaseDate.ToString("MM/dd/yyy", CultureInfo.InvariantCulture),
                    ProducerName = x.Producer.Name,
                    Songs = x.Songs
                        .Select(s => new
                        {
                            SongName = s.Name,
                            Price = s.Price.ToString("f2"),
                            Writer = s.Writer.Name
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.Writer)
                        .ToArray(),
                    AlbumPrice = x.Price.ToString("f2")
                })
                .ToArray();

            foreach (var a in albumsInfo)
            {
                sb
                    .AppendLine($"-AlbumName: {a.Name}")
                    .AppendLine($"-ReleaseDate: {a.releaseDate}")
                    .AppendLine($"-ProducerName: {a.ProducerName}")
                    .AppendLine($"-Songs:");

                    int i = 1;
               foreach (var s in a.Songs)
                {
                    sb
                        .AppendLine($"---#{i}")
                        .AppendLine($"---SongName: {s.SongName}")
                        .AppendLine($"---Price: {s.Price}")
                        .AppendLine($"---Writer: {s.Writer}");

                    i++;
                }

            sb.AppendLine($"-AlbumPrice: {a.AlbumPrice}");
            }


            return sb.ToString().TrimEnd();
        }


        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();

            var SongsAboveDuration = context.Songs
                .AsEnumerable()
                .Where(x => x.Duration.TotalSeconds > duration)
                .Select(x => new
                {
                    name = x.Name,
                    performer = x.SongPerformers
                        .Select(p => $"{p.Performer.FirstName} {p.Performer.LastName}")
                        .OrderBy(p => p)
                        .ToArray(),

                    writer = x.Writer.Name,
                    albumProducer = x.Album.Producer.Name,
                    timeDuration = x.Duration,
                })
                .OrderBy(x => x.name)
                .ThenBy(x => x.writer);

            int i = 1;

            foreach (var s in SongsAboveDuration)
            {
                sb
                    .AppendLine($"-Song #{i}")
                    .AppendLine($"---SongName: {s.name}")
                    .AppendLine($"---Writer: {s.writer}");

                           foreach (var p in s.performer)
                           {
                               sb.AppendLine($"---Performer: {p}"); ;
                           }

                sb
                    .AppendLine($"---AlbumProducer: {s.albumProducer}")
                    .AppendLine($"---Duration: {s.timeDuration}");

                    i++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
