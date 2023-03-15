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

            Console.WriteLine(GetAuthorNamesEndingIn(db, "e"));
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorsNamesEndingIn = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .OrderBy(x => x.FirstName).ThenBy(x => x.LastName)
                .Select(x => $"{x.FirstName} {x.LastName}");

            return string.Join(Environment.NewLine, authorsNamesEndingIn);
        }
    }
}


