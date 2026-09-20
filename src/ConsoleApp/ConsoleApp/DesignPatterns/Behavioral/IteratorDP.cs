using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.DesignPatterns.Behavioral.Iterator
{

    /// <summary>
    /// Iterator Interface
    /// Defines the methods for accessing and traversing the collection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IIterator<T>
    {
        bool HasNext();
        T next();
    }

    /// <summary>
    /// Defines the method for creating an iterator
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface Aggregate<T>
    {
        IIterator<T> CreateIIterator();
    }

    /// <summary>
    /// Concreate Iterator
    /// Implements the iterator interface and provides the actual iteration logic
    /// </summary>
    class EmployeeIterator : IIterator<Employee>
    {
        private int _currentIndex = 0;
        private readonly List<Employee> _employees;

        public EmployeeIterator(List<Employee> employees)
        {
            this._employees = employees;
        }

        public bool HasNext()
        {
            return _currentIndex < _employees.Count;
        }

        public Employee next()
        {
            if (!HasNext())
                throw new InvalidOperationException("No more elements.");

            // 3. Post-increment index (_currentIndex++) so it advances to the next item
            return _employees[_currentIndex++];
        }
    }

    /// <summary>
    /// Concrete Aggregate
    /// Implements the aggregate interface and provides the method to create and iterator for the collection
    /// </summary>
    public class Company : Aggregate<Employee>
    {
        private readonly List<Employee> _employees;

        public Company(List<Employee> employees)
        {
            this._employees = employees;
        }

        public IIterator<Employee> CreateIIterator()
        {
            return new EmployeeIterator(this._employees);
        }
    }

    public class Employee
    {
        private readonly string _name;
        private readonly double _salary;

        public Employee(string name, double salary)
        {
            this._name = name;
            this._salary = salary;
        }

        public double getSalary()
        {
            return _salary;
        }
    }

    public static class IteratorDP
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
            IIterator<Employee> iterator = company.CreateIIterator();

            double totalSalary = 0;
            while (iterator.HasNext())
            {
                totalSalary += iterator.next().getSalary();
            }
            Console.WriteLine($"Total salary: {totalSalary}");
        }
    }

}
