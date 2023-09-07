using System;
using System.Collections.Generic;

namespace SalaryIncrease
{
    // Exercise: Access modifiers Task #1

    public class Person
    {
        private string firstName;

        private string lastName;

        private int age;

        private double salary;

        public Person(string firstName, string lastName, int age, double salary)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.salary = salary;
        }

        public string FirstName
        {
            get { return firstName; }
        }

        public string LastName
        {
            get { return lastName; }
        }

        public int Age
        {
            get { return age; }
        }

        public double Salary
        {
            get { return salary; }
        }

        public void IncreaseSalary(double bonus)
        {
            if (this.age < 30)
            {
                this.salary += ((bonus / 100) * this.salary) / 2;
            }
            else
            {
                this.salary += (bonus / 100) * this.salary;
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} get {Salary:F2} leva";
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var people = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                var personArguments = Console.ReadLine().Split();

                var person = new Person(personArguments[0], 
                                        personArguments[1], 
                                        int.Parse(personArguments[2]), 
                                        double.Parse(personArguments[3])
                             );

                people.Add(person);
            }

            var bonus = double.Parse(Console.ReadLine());

            people.ForEach(p =>
            {
                p.IncreaseSalary(bonus);
                Console.WriteLine(p.ToString());
            });
        }
    }
}
