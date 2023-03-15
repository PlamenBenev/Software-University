namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetBooksReleasedBefore(db, "12-04-1992"));
        }
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var booksReleasedBefore = context.Books
                .Where(b => b.ReleaseDate < DateTime
                    .ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price}");

            return string.Join(Environment.NewLine, booksReleasedBefore);
        }
    }
}


