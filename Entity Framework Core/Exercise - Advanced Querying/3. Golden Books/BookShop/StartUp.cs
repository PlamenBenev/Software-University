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

            Console.WriteLine(GetGoldenBooks(db));
        }
        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var goldenBooks = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .Select(b => new { b.Title , b.BookId})
                .OrderBy(b => b.BookId)
                .ToArray();

            foreach (var book in goldenBooks) { sb.AppendLine(book.Title); }

            return sb.ToString().TrimEnd();
        }

    }
}


