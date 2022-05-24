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
            string queInput = Console.ReadLine();
            string stackInput = Console.ReadLine();

            Queue<char> vowelsQueue = new Queue<char>();
            Stack<char> consonantStack = new Stack<char>();

            List<char> pear = new List<char>();
            List<char> flour = new List<char>();
            List<char> pork = new List<char>();
            List<char> olive = new List<char>();

            List<string> words = new List<string>();

            foreach (var item in queInput)
            {
                if (item != ' ')
                    vowelsQueue.Enqueue(item);
            }
            foreach (var item in stackInput)
            {
                if (item != ' ')
                    consonantStack.Push(item);
            }

            while (consonantStack.Count > 0)
            {
                char vowel = vowelsQueue.Peek();
                char consonant = consonantStack.Peek();

                if ("pear".Contains(vowelsQueue.Peek()))
                {
                    if (!pear.Contains(vowelsQueue.Peek()))
                    {
                        pear.Add(vowel);
                    }
                }
                if ("pear".Contains(consonant))
                {
                    if (!pear.Contains(consonant))
                    {
                        pear.Add(consonant);
                    }
                }
                if ("flour".Contains(vowelsQueue.Peek()))
                {
                    if (!flour.Contains(vowelsQueue.Peek()))
                    {
                        flour.Add(vowel);
                    }
                }
                if ("flour".Contains(consonant))
                {
                    if (!flour.Contains(consonant))
                    {
                        flour.Add(consonant);
                    }
                }
                if ("pork".Contains(vowelsQueue.Peek()))
                {
                    if (!pork.Contains(vowelsQueue.Peek()))
                    {
                        pork.Add(vowel);
                    }
                }
                if ("pork".Contains(consonant))
                {
                    if (!pork.Contains(consonant))
                    {
                        pork.Add(consonant);
                    }
                }
                if ("olive".Contains(vowelsQueue.Peek()))
                {
                    if (!olive.Contains(vowelsQueue.Peek()))
                    {
                        olive.Add(vowelsQueue.Peek());
                    }
                }
                if ("olive".Contains(consonant))
                {
                    if (!olive.Contains(consonant))
                    {
                        olive.Add(consonant);
                    }
                }
                vowelsQueue.Enqueue(vowelsQueue.Dequeue());
                consonantStack.Pop();
            }
            if (pear.Count >= 4)
            {
                words.Add("pear");
            }
            if (flour.Count >= 5)
            {
                words.Add("flour");
            }
            if (pork.Count >= 4)
            {
                words.Add("pork");
            }
            if (olive.Count >= 5)
            {
                words.Add("olive");
            }
            Console.WriteLine($"Words found: {words.Count}");
            for (int i = 0; i < words.Count; i++)
            {
                Console.WriteLine(words[i]);
            }
        }
    }
}