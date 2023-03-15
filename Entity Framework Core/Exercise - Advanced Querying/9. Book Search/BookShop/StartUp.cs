namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore.Metadata;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetBookTitlesContaining(db, "sK"));
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var bookTitles = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(x => x.Title)
                .Select(x => x.Title);

            return string.Join(Environment.NewLine, bookTitles);
        }
    }
}


