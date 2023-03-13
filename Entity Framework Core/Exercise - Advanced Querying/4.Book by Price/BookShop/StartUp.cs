namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetBooksByPrice(db));
        }
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => $"{b.Title} - ${b.Price:F2}");

            return string.Join(Environment.NewLine, books);
        }
        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var goldenBooks = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .Select(b => new { b.Title, b.BookId })
                .OrderBy(b => b.BookId)
                .ToArray();

            foreach (var book in goldenBooks) { sb.AppendLine(book.Title); }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            var bookTitles = context.Books
                .Where(x => Enum.Parse<AgeRestriction>(command, true) == x.AgeRestriction)
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToArray();

            foreach (var b in bookTitles)
            {
                sb.AppendLine($"{b}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}


