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

            Console.WriteLine(GetBooksByAgeRestriction(db, "miNor"));
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


