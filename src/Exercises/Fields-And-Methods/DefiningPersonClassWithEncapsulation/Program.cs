using System;
using System.Collections.Generic;

namespace DefiningPersonClassWithEncapsulation
{
    public class Person
    {
        private string name;

        private int age;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Person firstPerson = new Person
            {
                Name = "Pesho",
                Age = 20
            };

            Person secondPerson = new Person
            {
                Name = "Gosho",
                Age = 18
            };

            Person thirdPerson = new Person
            {
                Name = "Stamat",
                Age = 43
            };

            List<Person> people = new List<Person>
            {
                firstPerson,
                secondPerson,
                thirdPerson
            };

            foreach (var person in people)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
            }
        }
    }
}
