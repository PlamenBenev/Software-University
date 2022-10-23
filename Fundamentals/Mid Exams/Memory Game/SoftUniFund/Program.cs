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

            string[] onput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            List<string> nums = new List<string>();
            for (int i = 0; i < onput.Length; i++)
            {
                nums.Add(onput[i]);
            }
            int counter = 0;
            int counter2 = -1;
            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] indexer = input.Split();
                int index0 = int.Parse(indexer[0]);
                int index1 = int.Parse(indexer[1]);

                if (index0 >= 0 && index1 >= 0 && index0 < nums.Count && index1 < nums.Count && nums[index0] == nums[index1] && index0 != index1)
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {nums[index0]}!");

                    if (index0 > index1)
                    {
                        nums.Remove(nums[index1]);
                        nums.Remove(nums[index0 - 1]);
                    }
                    else
                    {
                        nums.Remove(nums[index0]);
                        nums.Remove(nums[index1 - 1]);
                    }
                    counter++;
                }
                else if (index0 < 0 || index1 < 0 || index0 >= nums.Count || index1 >= nums.Count || index0 == index1)
                {
                    string adding = counter2.ToString() + "a";
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    nums.Insert(nums.Count / 2, adding);
                    nums.Insert(nums.Count / 2, adding);
                }
                else
                {
                    Console.WriteLine("Try again!");
                }
                if (nums.Count == 0)
                {
                    Console.WriteLine($"You have won in {counter} turns!");
                    break;
                }
                input = Console.ReadLine();
                if (input == "end")
                {
                    Console.WriteLine("Sorry you lose :(");
                    Console.WriteLine(String.Join(' ', nums));
                    break;
                }
                counter2--;
            }

        }

    }
}