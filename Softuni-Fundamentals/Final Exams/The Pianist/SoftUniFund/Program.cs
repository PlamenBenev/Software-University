using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace SoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string input = "";
            List<Col> col = new List<Col>();
            for (int i = 0; i < num; i++)
            {
                input = Console.ReadLine();
                string[] token = input.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                Col colect = new Col(token[0], token[1], token[2]);
                col.Add(colect);
            }
            input = Console.ReadLine();

            while (input != "Stop")
            {
                string[] token = input.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                if (token[0] == "Add")
                {
                    Col colect = new Col(token[1], token[2], token[3]);
                    bool wehaveit = false;
                    foreach (var item in col)
                    {
                        if (item.Piece == token[1])
                        {
                            wehaveit = true;
                        }
                    }
                    if (!wehaveit)
                    {
                        col.Add(colect);
                        Console.WriteLine($"{token[1]} by {token[2]} in {token[3]} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{token[1]} is already in the collection!");
                    }
                }
                else if (token[0] == "Remove")
                {
                    bool isitthere = false;
                    foreach (var item in col)
                    {
                        if (item.Piece == token[1])
                        {
                            Console.WriteLine($"Successfully removed {item.Piece}!");
                            col.Remove(item);
                            isitthere = true;
                            break;
                        }
                    }
                    if (!isitthere)
                        Console.WriteLine($"Invalid operation! {token[1]} does not exist in the collection.");
                }
                else if (token[0] == "ChangeKey")
                {
                    bool isitthere = false;
                    foreach (var item in col)
                    {
                        if (token[1] == item.Piece)
                        {
                            Console.WriteLine($"Changed the key of {item.Piece} to {token[2]}!");
                            item.Key = token[2];
                            isitthere = true;
                            break;
                        }
                    }
                    if (!isitthere)
                    {
                        Console.WriteLine($"Invalid operation! {token[1]} does not exist in the collection.");
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var item in col)
            {
                Console.WriteLine($"{item.Piece} -> Composer: {item.Composer}, Key: {item.Key}");
            }
        }
    }
}
class Col
{
    public Col(string piece, string composer, string key)
    {
        Piece = piece;
        Composer = composer;
        Key = key;
    }
    public string Piece { get; set; }
    public string Composer { get; set; }
    public string Key { get; set; }

}