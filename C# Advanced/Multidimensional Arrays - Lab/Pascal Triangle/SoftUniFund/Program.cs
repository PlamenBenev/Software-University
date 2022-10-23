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
            int num = int.Parse(Console.ReadLine());

            long[][] arr = new long[num][];

            for (int main = 0; main < num; main++)
            {
                if (main == 0)
                {
                    arr[main] = new long[1] { 1 };
                }
                else
                {
                    arr[main] = new long[arr[main - 1].Length + 1];
                    for (int jag = 0; jag < arr[main].Length; jag++)
                    {
                        if (jag == arr[main].Length - 1)
                        {
                            arr[main][jag] = arr[main - 1][jag - 1];
                        }
                        else if (jag == 0)
                        {
                            arr[main][jag] = 1;
                        }
                        else
                            arr[main][jag] = arr[main - 1][jag] + arr[main - 1][jag - 1];
                    }
                }
                Console.WriteLine(String.Join(' ', arr[main]));
            }
        }
    }
}