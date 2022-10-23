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
            int capacity = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            List<User> persons = new List<User>();

            while (input != "Statistics")
            {
                string[] token = input.Split('=');
                if (token[0] == "Add")
                {
                    User person = new User(token[1], int.Parse(token[2]), int.Parse(token[3]));
                    bool dowehaveit = false;
                    foreach (var item in persons)
                    {
                        if (item.Name == token[1])
                        {
                            dowehaveit = true;
                        }
                    }
                    if (!dowehaveit)
                    {
                        persons.Add(person);
                    }
                }
                else if (token[0] == "Message")
                {
                    bool sender = false;
                    bool reciever = false;
                    foreach (var item in persons)
                    {
                        if (item.Name == token[1])
                        {
                            sender = true;
                        }
                        if (item.Name == token[2])
                        {
                            reciever = true;
                        }
                    }
                    if (sender && reciever)
                    {
                        foreach (var item in persons)
                        {
                            if (item.Name == token[1])
                            {
                                item.Sent++;
                                if (item.Sent + item.Recieved >= capacity)
                                {
                                    Console.WriteLine($"{item.Name} reached the capacity!");
                                    persons.Remove(item);
                                    break;
                                }
                            }
                        }
                        foreach (var item in persons)
                        {
                            if (item.Name == token[2])
                            {
                                item.Recieved++;
                                if (item.Recieved + item.Sent >= capacity)
                                {
                                    Console.WriteLine($"{item.Name} reached the capacity!");
                                    persons.Remove(item);
                                    break;
                                }
                            }
                        }
                    }
                }
                else if (token[0] == "Empty")
                {
                    if (token[1] == "All")
                    {
                        persons.Clear();
                    }
                    else
                    {
                        foreach (var item in persons)
                        {
                            if (token[1] == item.Name)
                            {
                                persons.Remove(item);
                                break;
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Users count: {persons.Count}");
            foreach (var item in persons)
            {
                int sum = item.Sent + item.Recieved;
                Console.WriteLine($"{item.Name} - {sum}");
            }
        }
    }
}

class User
{
    public User(string name, int sent, int recieved)
    {
        Name = name;
        Sent = sent;
        Recieved = recieved;
    }
    public string Name { get; set; }
    public int Sent { get; set; }
    public int Recieved { get; set; }
}