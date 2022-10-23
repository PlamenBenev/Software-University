using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> first = Console.ReadLine().Split(',').ToList();
            Article article = new Article(first[0], first[1], first[2]);

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string input = Console.ReadLine();
                string[] token = input.Split(':');

                if (token[0] == "Edit")
                {
                    article.Content = token[1];
                }
                else if (token[0] == "ChangeAuthor")
                {
                    article.Author = token[1];
                }
                else if (token[0] == "Rename")
                {
                    article.Title = token[1];
                }
            }
            Console.WriteLine(article);
        }
    }
}

class Article
{
    public Article(string newTitle, string newContent, string newAuthor)
    {
        this.Content = newContent;
        this.Author = newAuthor;
        this.Title = newTitle;

    }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }

    public override string ToString()
    {
        return $"{Title} -{Content}:{Author}";
    }
}