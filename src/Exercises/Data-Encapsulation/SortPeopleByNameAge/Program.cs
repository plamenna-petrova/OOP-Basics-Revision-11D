using System;
using System.Collections.Generic;
using System.Linq;

namespace SortPeopleByNameAge
{
    // Exercise: Encapsulation this Task #2

    public class Person
    {
        private string firstName;

        private string lastName;

        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        public string FirstName
        {
            get { return this.firstName; }
        }

        public string LastName
        {
            get { return this.lastName; }
        }

        public int Age
        {
            get { return this.age; }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} is a {Age} years old";
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
                var person = new Person(personArguments[0], personArguments[1], int.Parse(personArguments[2]));
                people.Add(person);
            }

            people.OrderBy(p => p.FirstName)
                  .ThenBy(p => p.Age)
                  .ToList()
                  .ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
