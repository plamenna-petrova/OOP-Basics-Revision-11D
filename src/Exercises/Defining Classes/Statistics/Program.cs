using System;
using System.Collections.Generic;
using System.Linq;

namespace Statistics
{
    public class Person
    {
        private string name;

        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name { get => name; set => name = value; }

        public int Age { get => age; set => age = value; }
    }

    public class Program
    {
        static void PrintPeopleStatistics(List<Person> people)
        {
            List<Person> filteredPeopleForStatistics = people
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ToList();

            foreach (Person person in filteredPeopleForStatistics)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }

        static void Main(string[] args)
        {
            int numberOfPeopleForStatistics = int.Parse(Console.ReadLine());

            List<Person> peopleForStatistics = new List<Person>();

            while (numberOfPeopleForStatistics > 0)
            {
                string[] personStatisticsDetails = Console.ReadLine().Split().ToArray();
                string personName = personStatisticsDetails[0];
                int personAge = int.Parse(personStatisticsDetails[1]);

                Person person = new Person(personName, personAge);
                peopleForStatistics.Add(person);    

                numberOfPeopleForStatistics--;
            }

            PrintPeopleStatistics(peopleForStatistics);
        }
    }
}
