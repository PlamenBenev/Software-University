using System;
using System.Globalization;
using System.Linq;

namespace SoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();


            string input = Console.ReadLine();
            int shotTargets = 0;

            while (input != "End")
            {
                int index = int.Parse(input);

                if (index < arr.Length)
                {
                    shotTargets++;
                    int stat = arr[index];
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] > stat && arr[i] != -1 && index != i)
                        {
                            arr[i] -= stat;
                        }
                        else if (arr[i] != -1 && index != i)
                        {
                            arr[i] += stat;
                        }
                    }
                    arr[index] = -1;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Shot targets: {shotTargets} -> {String.Join(' ', arr)}");
        }
    }
}