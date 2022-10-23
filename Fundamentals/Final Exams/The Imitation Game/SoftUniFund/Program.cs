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
            string word = Console.ReadLine();
            string input = Console.ReadLine();
            string newWord = "";
            while (input != "Decode")
            {
                string[] token = input.Split('|');
                if (token[0] == "Move")
                {
                    newWord = word.Substring(0, int.Parse(token[1]));
                    word = word.Remove(0, int.Parse(token[1]));
                    word += newWord;
                }
                else if (token[0] == "Insert")
                {
                    word = word.Insert(int.Parse(token[1]), token[2]);
                }
                else if (token[0] == "ChangeAll")
                {
                    word = word.Replace(token[1], token[2]);
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"The decrypted message is: {word}");
        }
    }
}
