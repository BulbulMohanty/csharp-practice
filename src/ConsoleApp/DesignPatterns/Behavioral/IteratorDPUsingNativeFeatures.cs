using ConsoleApp.DesignPatterns.Behavioral.Iterator;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.DesignPatterns.Behavioral.IteratorDPUsingNativeFeatures
{
    public class Company
    {
        private readonly List<Employee> _employees;

        public Company(List<Employee> employees)
        {
            _employees = employees;
        }

        /// <summary>
        /// The generic enumerator. C# builds the iterator state machine behind the scenes!
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> Employees
        {
            get
            {
                foreach (var employee in _employees)
                {
                    yield return employee;
                }
            }
        }

    }

    public class Employee
    {
        public string Name { get; }
        public double Salary { get; }

        public Employee(string name, double salary)
        {
            Name = name;
            Salary = salary;
        }
    }

    public static class IteratorDPUsingNativeFeatures
    {
        public static void Test()
        {
            List<Employee> employees = new List<Employee>() {
            new ("Alice", 50000),
            new ("Bob", 60000),
            new("Charlie", 70000),
            new ("Susil", 65000),
            new ("Mihir", 55000),
            new("Aniket", 75000)
            };

            Company company = new Company(employees);
            double totalSalary = 0;
            foreach (var item in company.Employees)
            {
                totalSalary += item.Salary;
            }
            Console.WriteLine($"Total salary: {totalSalary}");
        }
    }
}
