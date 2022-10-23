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
            Dictionary<char, string> dic = new Dictionary<char, string>();

            List<char> list = Console.ReadLine().ToList();

            foreach (char c in list)
            {
                if (!dic.ContainsKey(c))
                {
                    dic[c] = string.Empty;
                }
                dic[c] += c;
            }
            foreach (var item in dic)
            {
                if (item.Key != ' ')
                    Console.WriteLine(item.Key + " -> " + item.Value.Count());
            }
        }
    }
}