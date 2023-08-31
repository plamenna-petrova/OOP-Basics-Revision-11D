using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfEmployees
{
    // Exercise: Fields And Properties Task #3

    public class Employee
    {
        private string name;

        private double salary;

        private string position;

        private string department;

        private string email;

        private int age;

        public Employee()
        {

        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            int numberOfEmployees = int.Parse(Console.ReadLine());

            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < numberOfEmployees; i++)
            {
                string[] employeesInformation = new string[6];
                string[] employeesConsoleInput = Console.ReadLine().Split().ToArray();
                Array.Copy(employeesConsoleInput, employeesInformation, employeesConsoleInput.Length);

                string name = employeesInformation[0];
                double salary = double.Parse(employeesInformation[1]);
                string position = employeesInformation[2];
                string department = employeesInformation[3];

                Employee employee = new Employee
                {
                    Name = name,
                    Salary = salary,
                    Position = position,
                    Department = department
                };

                if (employeesInformation[4] != null)
                {
                    employee.Email = employeesInformation[4];
                }

                if (employeesInformation[5] != null)
                {
                    employee.Age = int.Parse(employeesInformation[5]);
                }

                employees.Add(employee);
            }

            var departmentWithHighestAverageSalary = employees
                     .GroupBy(e => e.Department)
                     .Select(dgr => new { Department = dgr.Key, Average = dgr.Average(e => e.Salary)})
                     .OrderByDescending(dgr => dgr.Average)
                     .First().Department;

            var employeesFromHighestAverageSalaryDepartment = employees
                     .Where(e => e.Department == departmentWithHighestAverageSalary)
                     .OrderByDescending(e => e.Salary)
                     .ToList();

            Console.WriteLine($"Highest Average Salary: {departmentWithHighestAverageSalary}");

            foreach (var employee in employeesFromHighestAverageSalaryDepartment)
            {
                string employeeDetails = $"{employee.Name} {employee.Salary:F2} ";

                if (employee.Email == default)
                {
                    employeeDetails += "n/a ";
                }
                else
                {
                    employeeDetails += $"{employee.Email} ";
                }

                if (employee.Age == default)
                {
                    employeeDetails += "-1";
                }
                else
                {
                    employeeDetails += $"{employee.Age}";
                }

                Console.WriteLine(employeeDetails);
            }
        }
    }
}
