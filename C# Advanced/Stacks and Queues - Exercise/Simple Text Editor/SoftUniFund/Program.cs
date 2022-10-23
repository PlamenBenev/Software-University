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
            int operations = int.Parse(Console.ReadLine());

            Stack<char> stack = new Stack<char>();
            Stack<string> doneOperations = new Stack<string>();

            for (int i = 0; i < operations; i++)
            {
                string[] input = Console.ReadLine().Split(' ');

                if (input[0] == "1")
                {
                    for (int j = 0; j < input[1].Length; j++)
                    {
                        stack.Push(input[1][j]);
                    }
                    doneOperations.Push(string.Join(' ', input));
                }
                else if (input[0] == "2")
                {
                    int timesPopping = int.Parse(input[1]);
                    string dequeued = "";
                    for (int pop = 0; pop < timesPopping; pop++)
                    {
                        dequeued += stack.Pop();
                    }
                    doneOperations.Push(string.Join(' ', input) + " " + dequeued);
                }
                else if (input[0] == "3")
                {
                    int elementIndex = int.Parse(input[1]) - 1;
                    string sequance = "";
                    foreach (var item in stack)
                    {
                        sequance += item;
                    }
                    string newSeq = "";
                    for (int k = sequance.Length - 1; k >= 0; k--)
                    {
                        newSeq += sequance[k];
                    }
                    if (elementIndex >= 0 && elementIndex < stack.Count)
                    {
                        Console.WriteLine(newSeq[elementIndex]);
                    }
                }
                else if (input[0] == "4")
                {
                    string[] token = doneOperations.Peek().Split(' ');

                    if (token[0] == "1")
                    {
                        for (int j = 0; j < token[1].Length; j++)
                        {
                            stack.Pop();
                        }
                    }
                    else if (token[0] == "2")
                    {

                        for (int k = token[2].Length - 1; k >= 0; k--)
                        {
                            stack.Push(token[2][k]);
                        }
                    }
                    doneOperations.Pop();
                }
            }
        }
    }
}