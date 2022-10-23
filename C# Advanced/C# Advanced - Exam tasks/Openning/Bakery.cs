using System;
using System.Collections.Generic;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public string Name { get; set; }
        public int Capacity { get; set; }

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }
        public void Add(Employee employee)
        {
            if (Employees.Count < Capacity)
            {
                Employees.Add(employee);
            }
        }
        public bool Remove(string name)
        {
            foreach (var item in Employees)
            {
                if (item.Name == name)
                {
                    Employees.Remove(item);
                    return true;
                }
            }
            return false;
        }
        public Employee GetOldestEmployee()
        {
            Employee employee = null;
            int oldest = 0;

            foreach (var item in Employees)
            {
                if (item.Age > oldest)
                {
                    oldest = item.Age;
                    employee = item;
                }
            }
            return employee;
        }
        public Employee GetEmployee(string name)
        {
            Employee employee = null;
            foreach (var item in Employees)
            {
                if (item.Name == name)
                {
                    employee = item;
                }
            }
            return employee;
        }
        public int Count
        {
            get { return Employees.Count; }
        }
        public string Report()
        {
            string returner = $"Employees working at Bakery {Name}:{Environment.NewLine}" +
                $"{string.Join(Environment.NewLine, Employees)}";

            return returner;
        }
    }
}
