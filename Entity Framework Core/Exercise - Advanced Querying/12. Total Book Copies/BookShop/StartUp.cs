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

            Console.WriteLine(CountCopiesByAuthor(db));
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authorCopies = context.Authors
                .OrderByDescending(x => x.Books.Sum(b => b.Copies))
                .Select(x => $"{x.FirstName} {x.LastName} - {x.Books.Sum(b => b.Copies)}");

            return string.Join(Environment.NewLine, authorCopies);
        }
    }
}


